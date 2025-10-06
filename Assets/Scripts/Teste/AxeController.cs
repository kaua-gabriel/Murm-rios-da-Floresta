using UnityEngine;

public class AxeController : MonoBehaviour
{
    public Collider axeTriggerCollider;
    public TerrainTreeManager treeManager;
    public float treeDetectionRadius = 2f;

    private void Start()
    {
        if (axeTriggerCollider != null)
        {
            axeTriggerCollider.enabled = false;
        }
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (axeTriggerCollider != null)
            {
                axeTriggerCollider.enabled = true;
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            if (axeTriggerCollider != null)
            {
                axeTriggerCollider.enabled = false;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Terrain"))
        {
            Vector3 hitPosition = transform.position;

            if (treeManager != null)
            {
                treeManager.DamageNearestTree(hitPosition, treeDetectionRadius);
            }
        }
    }
}
