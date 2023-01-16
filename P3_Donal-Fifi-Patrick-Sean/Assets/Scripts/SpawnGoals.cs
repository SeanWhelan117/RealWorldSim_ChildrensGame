using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnGoals : MonoBehaviour
{

    public Transform[] spawnPoints;
    public GameObject goal;
    int randomNum = 0;
    private GameObject clone;
    public GameObject star;

    float Xpos=-8.0f;
    Vector3 vec;


  

    // Start is called before the first frame update
    void Start()
    { 
        randomNum = Random.Range(0, 3);
        clone = Instantiate(goal, spawnPoints[randomNum].position, Quaternion.identity);
    }

   
    public void SpawnStar()
    {
        vec = new Vector3(Xpos, 4.0f, 0.0f);
        Xpos = Xpos + 1;
        star = Instantiate(star, vec, Quaternion.identity);
    }
    public void changePos()
    {
        Destroy(clone);
        randomNum = Random.Range(0, 4);
        clone = Instantiate(goal, spawnPoints[randomNum].position, Quaternion.identity);

    }
}
