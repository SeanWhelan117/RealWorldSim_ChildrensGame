using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Net;
using UnityEngine.Networking;
using System;

public class CalculateScore : MonoBehaviour
{
    public string randSession;
    public int shotsF = 1;
    public int shotsH = 2;
    public int Shots_Fired;
    public int Shots_hit;
    public int Shots_Missed;
    public float Evaluation_Score;
    public GameObject luggage;
    public GameObject LuggageIdentfier;

    //timer
    public float secondsCount;
    public int secondsCountInt;

    //bool
    public bool sendOff = false;

    // public int Evaluation_Score;

    private void Start()
    {
        randSession = SystemInfo.deviceUniqueIdentifier;
        sendOff = true;
    }
    // Start is called before the first frame update
    void Update()
    {
        Shots_Fired = luggage.gameObject.GetComponent<Luggage>().shotsFiredData;
        Shots_hit = luggage.gameObject.GetComponent<collision>().shotsHit;

        if (Shots_Fired != 0 && Shots_hit != 0)
        {
            Shots_Missed = Mathf.RoundToInt(Shots_hit / Shots_Fired);
            Evaluation_Score = Mathf.RoundToInt(Shots_Fired / Shots_Missed);
        }

        if (Shots_Missed>2)
        {
            //luggage.GetComponent<Luggage>().setColorSuitcase();
           
           // LuggageIdentfier.GetComponent<bubbleGoalScript>().setSuitCaseColour();
            Shots_Missed = 0;
        }
        if (Shots_hit > 3)
        {
            SendData();
            SceneManager.LoadScene("WinScene");

        }


        if (Input.GetKeyDown(KeyCode.J))
            {
                SendData();
            }




        secondsCount += Time.deltaTime;
        secondsCountInt = Mathf.RoundToInt(secondsCount);
    }

    private void FixedUpdate()
    {
        if(sendOff == true)
        {
            StartCoroutine(sendBoisOver());

        }

    }

    [System.Obsolete]
    public void SendData()
    {
        randSession = randSession = System.DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss-") + randSession;

        GameState data = new GameState { sessionId = randSession, shotsFired = Shots_Fired, shotsHit = Shots_hit, seconds = secondsCountInt };

        string jsonData = JsonUtility.ToJson(data);
        StartCoroutine(AnalythicManager.PostMethod(jsonData));
    }


    [System.Obsolete]
    IEnumerator sendBoisOver()
    {
        sendOff = false;
        yield return new WaitForSeconds(5);
        SendData();
        Debug.Log("data has been sent");
        sendOff = true;
    }

}
