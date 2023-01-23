using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Luggage : MonoBehaviour
{
    private bool isPressed;
    private bool isReleased;
    private Rigidbody2D rb;
    private SpringJoint2D joint;
    public float releaseDelay;
    public float maxDragDistance = 2.0f;
    private Rigidbody2D slingRb;
    private LineRenderer lineRen;
    private TrailRenderer trailRen;
    public GameObject m_goal;
    public GameObject m_sling;
    public GameObject GameManager;
    private bool isFired;
    public int shotsFiredData = 0;
    public float ColourTimer;
    
 

    private void Awake()
    {
      
        m_sling = GameObject.FindGameObjectWithTag("Sling");
        rb = GetComponent<Rigidbody2D>();
        joint = GetComponent<SpringJoint2D>();
        joint.distance = 0.005f;
        joint.frequency = 1.15f;
        joint.connectedBody = m_sling.GetComponent<Rigidbody2D>();
        slingRb = joint.connectedBody;
        releaseDelay = 1 / (joint.frequency * 4);
        lineRen = GetComponent<LineRenderer>();
        lineRen.enabled = false;
        trailRen = GetComponent<TrailRenderer>();
        setColorSuitcase();
        isReleased = false;
        isFired = false;
    }

    public void SetReleaseDelay(float t_releaseDelay)
    {
        releaseDelay = t_releaseDelay;
    }

    public void setColorSuitcase()
    {
        int ColorCounter = Random.Range(1, 4);
        if (ColorCounter==1)
        {
            gameObject.GetComponent<SpriteRenderer>().color = new Color(1.0f, 0.0f, 0.0f, 1.0f);
        }
        else if(ColorCounter == 2)
        {
            // set luggage to green if goal is green 
            gameObject.GetComponent<SpriteRenderer>().color = new Color(0.0f, 1.0f, 0.0f, 1.0f);
        }
        else if(ColorCounter == 3)
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

    private void Update()
    {

        ColourTimer += Time.deltaTime;
      
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            float distance = Vector2.Distance(mousePos, slingRb.position);
            if (distance <0.5f)
            {
                isPressed = true;
                rb.isKinematic = true;
                lineRen.enabled = true;
            }
        }

        if (Input.GetMouseButtonUp(0) && isPressed)
        {
            isFired = true;
            rb.isKinematic = false;
            StartCoroutine(Release());
            lineRen.enabled = false;
        }

        if (isPressed && isFired == false)
        {
            DragBall();
        }
        if (isReleased && isFired)
        {
            Debug.Log("fireddd");
            shotsFiredData += 1;
            joint.enabled = false;
            trailRen.enabled = true;
            onScreen();
        }
       
    }

    private void onScreen()
    {

    }

    private void DragBall()
    {
        SetLineRendererPosition();

        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        float distance = Vector2.Distance(mousePos, slingRb.position);
        if(distance > maxDragDistance)
        {
            Vector2 direction = (mousePos - slingRb.position).normalized;
            rb.position = slingRb.position + direction * maxDragDistance;
        }
        else
        {
            rb.position = mousePos;
        }
    }

    private void SetLineRendererPosition()
    {
        Vector3[] positions = new Vector3[2];
        positions[0] = rb.position;
        positions[1] = slingRb.position;
        lineRen.SetPositions(positions);
    }

    private IEnumerator Release()
    {
        //yield return new WaitForSeconds(releaseDelay);
        //shotsFiredData += 1;
        //joint.enabled = false;
        //trailRen.enabled = true;

        yield return new WaitForSeconds(3.0f);
        ResetLuggage();
    }

    public void ResetLuggage()
    {
        transform.position = new Vector3(-6f, -3f, 0.0f);
        lineRen.enabled = false;
        trailRen.enabled = false;
        isReleased = false;
        isFired = false;
        isPressed = false;
        joint.enabled = true;
        setColorSuitcase();
        GameManager.GetComponent<CalculateScore>().Shots_Missed += 1;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Sling"))
        {
            Debug.Log("collided with goal");
            if (isFired)
            {
                isReleased = true;
            }

        }
    }
}
