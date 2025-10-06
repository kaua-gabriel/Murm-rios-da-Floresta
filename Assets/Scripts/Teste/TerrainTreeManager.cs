using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainTreeManager : MonoBehaviour
{
    public Terrain terrain;
    public float respawnDelay = 10f;
    public int treeMaxHealth = 3;  // Vida máxima de cada árvore

    private Dictionary<Vector3, int> treeHealth = new Dictionary<Vector3, int>();

    public GameObject treeHitParticlePrefab;  // Referência ao prefab
    public float particleHeightOffset = 1.5f;  // Ajuste conforme o tamanho da sua árvore

    public void DamageNearestTree(Vector3 position, float radius)
    {
        TerrainData terrainData = terrain.terrainData;
        TreeInstance[] trees = terrainData.treeInstances;

        int closestIndex = -1;
        float minDistance = float.MaxValue;
        Vector3 closestWorldPos = Vector3.zero;
        int prototypeIndex = 0;

        for (int i = 0; i < trees.Length; i++)
        {
            Vector3 worldPos = Vector3.Scale(trees[i].position, terrainData.size) + terrain.transform.position;
            float distance = Vector3.Distance(position, worldPos);
            if (distance < minDistance && distance < radius)
            {
                minDistance = distance;
                closestIndex = i;
                closestWorldPos = worldPos;
                prototypeIndex = trees[i].prototypeIndex;
            }
        }

        if (closestIndex != -1)
        {
            if (treeHitParticlePrefab != null)
            {
                Vector3 particlePosition = closestWorldPos + Vector3.up * particleHeightOffset;
                Instantiate(treeHitParticlePrefab, particlePosition, Quaternion.identity);
            }

            // Verifica ou inicializa vida
            if (!treeHealth.ContainsKey(closestWorldPos))
            {
                treeHealth[closestWorldPos] = treeMaxHealth;
            }

            treeHealth[closestWorldPos]--;

            Debug.Log("Árvore em " + closestWorldPos + " sofreu dano. Vida restante: " + treeHealth[closestWorldPos]);

            if (treeHealth[closestWorldPos] <= 0)
            {
                // Remove árvore
                List<TreeInstance> treeList = new List<TreeInstance>(trees);
                treeList.RemoveAt(closestIndex);
                terrainData.treeInstances = treeList.ToArray();

                // Remove da lista de vida
                treeHealth.Remove(closestWorldPos);

                // Inicia respawn
                StartCoroutine(RespawnTree(closestWorldPos, prototypeIndex, respawnDelay));
            }
        }
    }

    private IEnumerator RespawnTree(Vector3 worldPosition, int prototypeIndex, float delay)
    {
        yield return new WaitForSeconds(delay);

        TerrainData terrainData = terrain.terrainData;
        List<TreeInstance> treeList = new List<TreeInstance>(terrainData.treeInstances);

        TreeInstance newTree = new TreeInstance();

        Vector3 normalizedPos = new Vector3(
            (worldPosition.x - terrain.transform.position.x) / terrainData.size.x,
            (worldPosition.y - terrain.transform.position.y) / terrainData.size.y,
            (worldPosition.z - terrain.transform.position.z) / terrainData.size.z
        );

        newTree.position = normalizedPos;
        newTree.prototypeIndex = prototypeIndex;
        newTree.widthScale = 1f;
        newTree.heightScale = 1f;
        newTree.color = Color.white;
        newTree.lightmapColor = Color.white;

        treeList.Add(newTree);
        terrainData.treeInstances = treeList.ToArray();

        // Reatribui vida
        treeHealth[worldPosition] = treeMaxHealth;

        Debug.Log("Árvore respawnada em " + worldPosition);
    }
}