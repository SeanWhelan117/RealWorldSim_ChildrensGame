using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    public Rigidbody2D rb;
    Vector2 vel;
    public GameObject goal;
    public GameObject manager;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("d"))
        {
            vel.x += 0.5f;
        }
        if (Input.GetKeyDown("a"))
        {
            vel.x -= 0.5f;
        }
        if (Input.GetKeyDown("w"))
        {
            vel.y += 0.5f;
        }
        if (Input.GetKeyDown("s"))
        {
            vel.y -= 0.5f;
        }
        rb.MovePosition(vel);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("goal"))
        {
            manager.gameObject.GetComponent<SpawnGoals>().changePos();
            manager.gameObject.GetComponent<SpawnGoals>().spawnStar();
            
        }
    }
}
