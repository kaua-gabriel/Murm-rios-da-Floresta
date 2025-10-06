using System.Collections.Generic;
using UnityEngine;

public class AxeTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Terrain"))
        {
            Terrain terrain = other.GetComponent<Terrain>();
            if (terrain != null)
            {
                Vector3 hitPosition = transform.position; // Posição do machado
                RemoveNearestTree(terrain, hitPosition, 2f); // 2f é a distância de remoção
            }
        }
    }

    void RemoveNearestTree(Terrain terrain, Vector3 position, float radius)
    {
        TerrainData terrainData = terrain.terrainData;
        TreeInstance[] trees = terrainData.treeInstances;
        int closestIndex = -1;
        float minDistance = float.MaxValue;

        for (int i = 0; i < trees.Length; i++)
        {
            Vector3 treeWorldPos = Vector3.Scale(trees[i].position, terrainData.size) + terrain.transform.position;
            float distance = Vector3.Distance(position, treeWorldPos);
            if (distance < minDistance && distance < radius)
            {
                minDistance = distance;
                closestIndex = i;
            }
        }

        if (closestIndex != -1)
        {
            List<TreeInstance> treeList = new List<TreeInstance>(trees);
            treeList.RemoveAt(closestIndex);
            terrainData.treeInstances = treeList.ToArray();
        }
    }
}
