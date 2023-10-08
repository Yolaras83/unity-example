using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nigga : MonoBehaviour
{
    public float Delay = 4f;
    public Transform player;
    public Transform Coin;
    public bool canSpawn;

    // Start is called before the first frame update
    void Start()
    {
        canSpawn = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (canSpawn == true)
        {
            StartCoroutine(StopSpawning());
        }
        if (canSpawn == false)
        {
            StartCoroutine(CoolDown());
        }
    }



    public IEnumerator CoolDown()
    {
        yield return new WaitForSeconds(5f);
        canSpawn = true;
    }

    public IEnumerator StopSpawning()
    {
        yield return new WaitForSeconds(1f);
        canSpawn = false;
    }
}
