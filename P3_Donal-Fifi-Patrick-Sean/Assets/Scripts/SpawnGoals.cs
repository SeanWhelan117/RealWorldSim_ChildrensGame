using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnGoals : MonoBehaviour
{

    public Transform[] spawnPoints;
    public GameObject goal;
    int randomNum = 0;
    private GameObject clone;
    // Start is called before the first frame update
    void Start()
    {

        randomNum = Random.Range(0, 3);
        clone = Instantiate(goal, spawnPoints[randomNum].position, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            Destroy(clone);
            randomNum = Random.Range(0, 4);
            clone =  Instantiate(goal, spawnPoints[randomNum].position, Quaternion.identity);
        }
    }
}
