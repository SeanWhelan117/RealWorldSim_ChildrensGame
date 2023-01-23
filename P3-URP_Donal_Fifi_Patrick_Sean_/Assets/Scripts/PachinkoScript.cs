using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PachinkoScript : MonoBehaviour
{
    BoxCollider2D _boxCol;
    // Start is called before the first frame update
    void Start()
    {
        _boxCol = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DisableEnableColliders()
    {
        _boxCol.enabled = false;
        StartCoroutine(ReEnableColliders());
    }

    private IEnumerator ReEnableColliders()
    {
        yield return new WaitForSeconds(2.0f);
        _boxCol.enabled = true;
    }
}
