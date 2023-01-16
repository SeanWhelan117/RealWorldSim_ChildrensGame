using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectCharacter : MonoBehaviour
{
    public GameObject luggage;
    public int characterSelected = 0;
    private SpringJoint2D joint;

    // Start is called before the first frame update
    void Start()
    {
        luggage = GameObject.FindWithTag("luggage");
        if (luggage != null)
        {
            joint = luggage.GetComponent<SpringJoint2D>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (luggage == null)
        {
            luggage = GameObject.FindWithTag("luggage");

        }
        else
        {
            joint = luggage.GetComponent<SpringJoint2D>();
        }
        if (joint != null)
        {
            //Debug.Log("Joint Attached");
            if (characterSelected == 0)
            {
                joint.frequency = 1.15f;
            }
            else if (characterSelected == 1)
            {
                joint.frequency = 1.30f;
            }
            else if (characterSelected == 2)
            {
                joint.frequency = 1.5f;

            }
        }
    }
}
