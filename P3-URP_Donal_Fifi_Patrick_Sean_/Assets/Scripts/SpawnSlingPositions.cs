using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnSlingPositions : MonoBehaviour
{
    public Transform[] spawnPoints;
    public GameObject sling;
    public GameObject luggage;

    float randomNum = 0.0f;
    private GameObject slingClone;
    private GameObject luggageClone;


    // Start is called before the first frame update
    void Start()
    {
        randomNum = Random.Range(2.0f, 6.5f);
        slingClone = Instantiate(sling, new Vector3(-randomNum, -1.5f, 0.0f), Quaternion.identity);
        slingClone.SetActive(true);

        luggageClone = Instantiate(luggage, new Vector3(-randomNum, -1.5f, 0.0f), Quaternion.identity);
        luggageClone.SetActive(true);
    }

    public void changePos()
    {
        randomNum = Random.Range(1.0f, 7.0f);

        slingClone.transform.position = new Vector3(-randomNum, -1.5f, 0.0f);
        luggageClone.GetComponent<Renderer>().enabled = false;
        luggageClone.GetComponent<Luggage>().resetAlive();
        luggageClone.GetComponent<TrailRenderer>().emitting = false;
    }
    
}
