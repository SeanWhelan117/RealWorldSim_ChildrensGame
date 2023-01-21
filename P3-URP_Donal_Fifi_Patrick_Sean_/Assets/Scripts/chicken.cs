using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chicken : MonoBehaviour
{
    public Rigidbody2D rb;
    public float Speed = 6;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        StartCoroutine(breakChicken());
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        rb.velocity = new Vector2(-Speed, 0);
    }

    IEnumerator breakChicken()
    {
        yield return new WaitForSeconds(60);
        Destroy(this.gameObject);

    }
}
