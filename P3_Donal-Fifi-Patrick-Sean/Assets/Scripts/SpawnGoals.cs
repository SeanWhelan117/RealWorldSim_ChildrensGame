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
<<<<<<< Updated upstream
    float Xpos=-8.0f;
    Vector3 vec;
=======
    Vector3 vec;
    float pos=-8.0f;
>>>>>>> Stashed changes
    // Start is called before the first frame update
    void Start()
    { 
        randomNum = Random.Range(0, 3);
        clone = Instantiate(goal, spawnPoints[randomNum].position, Quaternion.identity);
    }

   
    public void SpawnStar()
    {
<<<<<<< Updated upstream
     
        vec = new Vector3(Xpos, 4.0f, 0.0f);
        Xpos = Xpos + 1;
        star = Instantiate(star, vec, Quaternion.identity);
    }
    public void changePos()
    {
        Destroy(clone);
        randomNum = Random.Range(0, 4);
        clone = Instantiate(goal, spawnPoints[randomNum].position, Quaternion.identity);
=======
       
    }

    public void spawnStar()
    {
        vec = new Vector3 (pos, 4.0f, 0.0f );
        pos = pos + 2;
        star = Instantiate(star, vec, Quaternion.identity);
       
        
    }

    


    public void changePos()
    {
        
            Destroy(clone);
            randomNum = Random.Range(0, 4);
            clone = Instantiate(goal, spawnPoints[randomNum].position, Quaternion.identity);
        
>>>>>>> Stashed changes
    }
}
