using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Luggage : MonoBehaviour
{
    private bool isPressed;
    private bool isReleased;
    private Rigidbody2D rb;
    private SpringJoint2D joint;
    private float releaseDelay;
    public float maxDragDistance = 2.0f;
    private Rigidbody2D slingRb;
    private LineRenderer lineRen;
    private TrailRenderer trailRen;
    private bool isFired;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        joint = GetComponent<SpringJoint2D>();
        slingRb = joint.connectedBody;
        releaseDelay = 1 / (joint.frequency * 4);
        lineRen = GetComponent<LineRenderer>();
        lineRen.enabled = false;
        trailRen = GetComponent<TrailRenderer>();
        trailRen.enabled = false;   
        isReleased = false;
        isFired = false;
    }

    private void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            isPressed = true;
            rb.isKinematic = true;
            lineRen.enabled = true;
        }
        if (Input.GetMouseButtonUp(0))
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
        if (isReleased)
        {
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
        yield return new WaitForSeconds(releaseDelay);
        joint.enabled = false;
        trailRen.enabled = true;
        isReleased = true;
        yield return new WaitForSeconds(3.0f);
        Destroy(this.gameObject);
    }
}
