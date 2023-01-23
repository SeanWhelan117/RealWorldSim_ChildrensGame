using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowAnimation : MonoBehaviour
{
    private float upperLimit, lowerLimit;

    public bool addingScale, loweringScale;


    public Vector3 initialScale;
    public Vector3 newScale;


    // Start is called before the first frame update
    void Start()
    {
        initialScale = transform.localScale;
        newScale = initialScale;
        addingScale = true;
        loweringScale = false;
        upperLimit = initialScale.x + 0.10f;
        lowerLimit = initialScale.x - 0.10f;
    }

    void Update()
    {
        if (newScale.x > upperLimit)
        {
            addingScale = false;
            loweringScale = true;
        }

        if (newScale.x < lowerLimit)
        {
            addingScale = true;
            loweringScale = false;
        }

        transform.localScale = newScale;

    }


    private void FixedUpdate()
    {
        if (loweringScale)
        {
            newScale.x = newScale.x - 0.005f;
            newScale.y = newScale.y - 0.005f;
        }
        if (addingScale)
        {
            newScale.x = newScale.x + 0.005f;
            newScale.y = newScale.y + 0.005f;
        }

    }
}
