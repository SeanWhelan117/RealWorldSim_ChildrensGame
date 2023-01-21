using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class birdFlying : MonoBehaviour
{
    [Header("Bird object")]
    public Rigidbody2D rb;
    public float Speed = 6;
    public bool birdHit = false;
    [Header("Particle")]
    public GameObject expolosion;
    [Header("egg")]
    public GameObject egg;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        StartCoroutine(breakBird());
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.velocity = new Vector2(-Speed, 0);



        if (birdHit == true)
        {
            StartCoroutine(birdBye());
        }
    }



    IEnumerator breakBird()
    {
        yield return new WaitForSeconds(8);
        Destroy(this.gameObject);
        
    }


    IEnumerator birdBye()
    {
        this.gameObject.SetActive(false);
        GameObject part = Instantiate(expolosion, transform.position, transform.rotation);
        GameObject eggs = Instantiate(egg, transform.position, transform.rotation);
        yield return new WaitForSeconds(3);
        this.gameObject.SetActive(true);
        Destroy(this.gameObject);
        Destroy(part.gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("luggage"))
        {
            birdHit = true;
        }
    }

}

