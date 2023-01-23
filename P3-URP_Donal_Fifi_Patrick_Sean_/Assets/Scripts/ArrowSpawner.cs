using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowSpawner : MonoBehaviour
{
    public GameObject pullBackArrow;
    public GameObject shootForwardArrow;
    public GameObject luggage;

    private Vector3 initialLuggagePos;
    private GameObject arrow;
    private GameObject arrow2;
    private bool setupArrow2 = false;

    private Vector3 testPos = new Vector3(-1.5f, 0, 0);

    // Start is called before the first frame update
    void Start()
    {
        initialLuggagePos = luggage.transform.position;
        arrow = Instantiate(pullBackArrow);
        arrow.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (luggage.transform.position != initialLuggagePos && setupArrow2 == false)
        {
            arrow.SetActive(false);
            arrow2 = Instantiate(shootForwardArrow);
            arrow2.SetActive(true);
            setupArrow2 = true;
        }

        if(luggage.transform.position.x >= testPos.x && setupArrow2 == true)
        {
            arrow2.SetActive(false);
        }
    }
}
