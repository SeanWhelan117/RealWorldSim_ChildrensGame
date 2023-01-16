using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalScript : MonoBehaviour
{
    public int ColorSwitcher;
    void Start()
    {
        ColorSwitcher= Random.Range(1, 4);
        if(ColorSwitcher==1)
        {
            // if it is red
            gameObject.GetComponent<SpriteRenderer>().color = new Color(1.0f, 0.0f, 0.0f, 1.0f);
        }
        if (ColorSwitcher == 2)
        {
            // if it is green
            gameObject.GetComponent<SpriteRenderer>().color = new Color(0.0f, 1.0f, 0.0f, 1.0f);
        }
        if (ColorSwitcher == 3)
        {
            // if it is blue
            gameObject.GetComponent<SpriteRenderer>().color = new Color(0.0f, 0.0f, 1.0f, 1.0f);
        }
        if (ColorSwitcher == 4)
        {
            // if it is white
            gameObject.GetComponent<SpriteRenderer>().color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
        }
    }

   
}
