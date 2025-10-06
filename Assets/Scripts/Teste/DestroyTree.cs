using UnityEngine;

public class DestroyTree : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnColliderEnter(Collider other)
    {
        if (other.CompareTag("Axe"))
        {
            Destroy(gameObject);
        }
    }
}
