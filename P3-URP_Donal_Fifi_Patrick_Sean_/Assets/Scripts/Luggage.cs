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
    private bool isFired;
    public int shotsFiredData = 0;
    private bool isAlive;
    private bool isGrounded;

    public void resetAlive()
    {
        isAlive = false;
    }

    public void checkIsGrounded()
    {
        isGrounded = true;
        StartCoroutine(Release());
    }

    private void Awake()
    {
        m_sling = GameObject.FindGameObjectWithTag("Sling");
        rb = GetComponent<Rigidbody2D>();
        rb.isKinematic = true;
        joint = GetComponent<SpringJoint2D>();
        joint.distance = 0.005f;
        joint.frequency = 1.15f;
        joint.connectedBody = m_sling.GetComponent<Rigidbody2D>();
        slingRb = joint.connectedBody;
        releaseDelay = 1 / (joint.frequency * 4);
        lineRen = GetComponent<LineRenderer>();
        lineRen.enabled = false;
        trailRen = GetComponent<TrailRenderer>();
        trailRen.enabled = false;
        setColorSuitcase();
        isReleased = false;
        isFired = false;
        isAlive = true;
        isGrounded = false;

    }

    public void SetReleaseDelay(float t_releaseDelay)
    {
        releaseDelay = t_releaseDelay;
    }

    private void setColorSuitcase()
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

    private void Update()
    {



        if (Input.GetMouseButtonDown(0))
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            float distance = Vector2.Distance(mousePos, slingRb.position);
            if (distance < 0.75f)
            {
                isPressed = true;
                rb.isKinematic = true;
                lineRen.enabled = true;
            }
        }

        if (Input.GetMouseButtonUp(0) && isPressed)
        {
            isFired = true;
            lineRen.enabled = false;
            rb.isKinematic = false;


        }
        if (rb.transform.position.y < -3.8)
        {
            StartCoroutine(Reset());
        }

        //if (isFired == true)
        //{
        //    StartCoroutine(Release());
        //}

        if (isPressed && isFired == false)
        {
            DragBall();
        }
        if (isReleased && isFired)
        {
            //Debug.Log("fireddd");
            shotsFiredData += 1;
            joint.enabled = false;
            trailRen.enabled = true;
            if (isAlive)
            {
                trailRen.emitting = true;
            }
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
        if (distance > maxDragDistance)
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

    private IEnumerator Reset()
    {
        yield return new WaitForSeconds(1.0f);
                lineRen.enabled = false;
                ResetLuggage();
    }

    private IEnumerator Release()
    {
        yield return new WaitForSeconds(0.1f);
        //yield return new WaitForSeconds(releaseDelay);
        //shotsFiredData += 1;
        //joint.enabled = false;
        //trailRen.enabled = true;
        if (isGrounded == true)
        {
            yield return new WaitForSeconds(0.1f);
            if ((rb.velocity.x > -0.5 && rb.velocity.x < 0.5) && (rb.velocity.y > -0.5 && rb.velocity.y < 0.5))
            //if (rb.velocity.x == 0 && rb.velocity.y == 0)
            {
                lineRen.enabled = false;
                ResetLuggage();
            }
        }
    }

    public void ResetLuggage()
    {
        transform.position = slingRb.position;
        trailRen.enabled = false;
        trailRen.Clear();
        isReleased = false;
        isFired = false;
        isPressed = false;
        joint.enabled = true;
        rb.isKinematic = true;
        rb.velocity = Vector3.zero;
        rb.angularVelocity = 0;
        rb.rotation = 0;
        isAlive = true;
        isGrounded = false;
        this.gameObject.GetComponent<Renderer>().enabled = true;

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
