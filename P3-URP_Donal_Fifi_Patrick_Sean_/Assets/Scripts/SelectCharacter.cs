using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectCharacter : MonoBehaviour
{
    public GameObject luggage;
    public GameObject nitrogen;
    public GameObject hydrogen;
    public GameObject carbon;
   // public GameObject sling;


    public int characterSelected = 0;
    private SpringJoint2D joint;

    // Start is called before the first frame update
    void Start()
    {
        luggage = GameObject.FindWithTag("luggage");
        nitrogen = GameObject.FindWithTag("Nitrogen");
        hydrogen = GameObject.FindWithTag("Hydrogen");
        carbon = GameObject.FindWithTag("Carbon");
       // sling = GameObject.FindWithTag("Sling");
        //nitrogen.transform.position = new Vector3(sling.transform.position.x - 1, -4.0f, 0.0f);
        nitrogen.transform.position = new Vector3(-6.0f, -4.0f, 0.0f);

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
    }

    public void WeakForce()
    {
        if (joint != null)
        {
            joint.frequency = 1.15f;
        }
        nitrogen.transform.position = new Vector3(-6.0f, -4.0f, 0.0f);
        carbon.transform.position = new Vector3(1000.0f, 1000.0f, 0.0f);
        hydrogen.transform.position = new Vector3(1000.0f, 1000.0f, 0.0f);
    }

    public void NormalForce()
    {
        if (joint != null)
        {
            joint.frequency = 1.3f;
        }
        hydrogen.transform.position = new Vector3(-6.0f, -4.0f, 0.0f);
        carbon.transform.position = new Vector3(1000.0f, 1000.0f, 0.0f);
        nitrogen.transform.position = new Vector3(1000.0f, 1000.0f, 0.0f);
    }

    public void StrongForce()
    {
        if (joint != null)
        {
            joint.frequency = 1.5f;
        }
        carbon.transform.position = new Vector3(-6.0f, -4.0f, 0.0f);
        hydrogen.transform.position = new Vector3(1000.0f, 1000.0f, 0.0f);
        nitrogen.transform.position = new Vector3(1000.0f, 1000.0f, 0.0f);
    }
}
