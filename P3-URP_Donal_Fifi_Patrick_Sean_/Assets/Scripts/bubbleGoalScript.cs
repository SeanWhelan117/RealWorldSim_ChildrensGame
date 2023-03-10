using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bubbleGoalScript : MonoBehaviour
{
    public GameObject Goal;
    // Start is called before the first frame update
    public float TimerGlobal;
    public GameObject RectCounter;
    private Vector3 scaleChange;
    private Vector3 scalereset;
    float decrement= 0.0002f;
    void Start()
    { 
       gameObject.GetComponent<SpriteRenderer>().color = Goal.gameObject.GetComponent<SpriteRenderer>().color;
        TimerGlobal = 0;
        scalereset= new Vector3(.95f, 0.5f, 0.0f);
        scaleChange = new Vector3 ( .95f, 0.5f, 0.0f );


    }
    private void Update()
    {
        TimerGlobal += Time.deltaTime;
        scaleChange.x -= decrement;
        if (scaleChange.x < 0.01)
        {
            setSuitCaseColour();
            scaleChange = scalereset;
            TimerGlobal = 0;
        }
       
        RectCounter.gameObject.transform.localScale = scaleChange;

    }
    
    public  void setSuitCaseColour()
    {
        int ColorCounter = Random.Range(1, 4);
        if (ColorCounter == 1)
        {
            gameObject.GetComponent<SpriteRenderer>().color = new Color(1.0f, 0.0f, 0.0f, 1.0f);
        }
        else if (ColorCounter == 2)
        {
            // set luggage to green if goal is green 
            gameObject.GetComponent<SpriteRenderer>().color = new Color(0.0f, 1.0f, 0.0f, 1.0f);
        }
        else if (ColorCounter == 3)
        {
            // set luggage to blue if goal is blue 
            gameObject.GetComponent<SpriteRenderer>().color = new Color(0.0f, 0.0f, 1.0f, 1.0f);
        }
        else if (ColorCounter == 4)
        {
            // set luggage to white if goal is white 
            gameObject.GetComponent<SpriteRenderer>().color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
        }
    }
   


}
