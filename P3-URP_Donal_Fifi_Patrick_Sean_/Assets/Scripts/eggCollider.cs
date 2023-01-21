using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class eggCollider : MonoBehaviour
{
    [Header("chicken")]
    public GameObject chicken;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("ground"))
        {
            GameObject chick = Instantiate(chicken, transform.position, transform.rotation);
        }
    }
}
