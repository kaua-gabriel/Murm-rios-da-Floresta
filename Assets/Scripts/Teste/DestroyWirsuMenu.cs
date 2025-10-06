using System;
using System.Collections;
using UnityEngine;

public class DestroyWirsuMenu : MonoBehaviour
{

    public GameObject wirsu;
    public float timeInside = 60f;
    private bool isBurning = false;

    private void Start()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("BallW") && !isBurning)
        {
           isBurning = true;
           StartCoroutine(DestroyTimer(timeInside));
        }
    }

    private void Update()
    {
    }

    private IEnumerator DestroyTimer(float delay)
    {
        if (isBurning) yield return null;

        yield return new WaitForSeconds(delay);


        Destroy(wirsu);

        isBurning = false;
    }

}
