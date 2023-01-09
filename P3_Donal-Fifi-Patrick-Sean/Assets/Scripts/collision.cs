using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collision : MonoBehaviour
{
    public GameObject goal;
    public GameObject GameManager;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("goal"))
        {
            Debug.Log("collided with goal");
            GameManager.GetComponent<SpawnGoals>().changePos();
            GameManager.GetComponent<SpawnGoals>().SpawnStar();
            //this.gameObject.GetComponent<Luggage>().ResetLuggage();
        }
    }
}
