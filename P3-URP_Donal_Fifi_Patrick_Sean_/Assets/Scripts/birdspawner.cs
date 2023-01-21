using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class birdspawner : MonoBehaviour
{
    public GameObject bird;
    public float TimeBetweenTryingToSpawn;
    public float randomNum;
    public Transform pos;
    public bool canSpawn = false;
    // Start is called before the first frame update
    void Start()
    {
        canSpawn = true;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(canSpawn == true)
            StartCoroutine(SpawnBird());
    }


    IEnumerator SpawnBird()
    {
        randomNum = Random.Range(1, 15);
        canSpawn=false;
        yield return new WaitForSeconds(TimeBetweenTryingToSpawn);
        if (randomNum == 7)
        {
             GameObject birdy = Instantiate(bird, pos.position, pos.rotation);
        }
        canSpawn=true;  
    }
}
