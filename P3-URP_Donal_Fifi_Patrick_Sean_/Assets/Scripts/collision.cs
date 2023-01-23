using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collision : MonoBehaviour
{
    public GameObject goal;
    public GameObject GameManager;
    public int shotsHit;
    // Start is called before the first frame update
    void Awake()
    {
        GameManager = GameObject.FindGameObjectWithTag("GameManager");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("goal"))
        {
            GameManager.GetComponent<SpawnSlingPositions>().changePos();
            shotsHit++;  
        }
        if (collision.gameObject.CompareTag("Roof"))
        {
            Debug.Log("OnRoof");
            this.gameObject.GetComponent<Luggage>().checkIsGrounded();
        }
        if (collision.gameObject.CompareTag("ground"))
        {
            Debug.Log("OnGround");
            this.gameObject.GetComponent<Luggage>().checkIsGrounded();

        }
        if (collision.gameObject.CompareTag("Pachinko"))
        {
            Debug.Log("Pachinko");
            collision.gameObject.GetComponent<PachinkoScript>().DisableEnableColliders();
        }
    }
}
