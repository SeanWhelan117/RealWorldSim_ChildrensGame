using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Net;
using UnityEngine.Networking;

public class CalculateScore : MonoBehaviour
{
    public int randSession;
    public int shotsF = 1;
    public int shotsH = 2;
    public int Shots_Fired;
    public int Shots_hit;
    public int Shots_Missed;
    public GameObject luggage;
    public GameObject LuggageIdentfier;
   
   // public int Evaluation_Score;

    private void Start()
    {
        
        randSession = Random.Range(1, 1000);
    }
    // Start is called before the first frame update
    void Update()
    {
        //Shots_Fired = luggage.gameObject.GetComponent<Luggage>().shotsFiredData;
        //Shots_hit = luggage.gameObject.GetComponent<collision>().shotsHit;

        //if(Shots_Fired!=0&&Shots_hit!=0)
        //{
        //    Shots_Missed = Mathf.RoundToInt(Shots_hit / Shots_Fired);
        //    Evaluation_Score = Mathf.RoundToInt(Shots_Fired / Shots_Missed); 
        //}
     
        if(Shots_Missed>2)
        {
            luggage.GetComponent<Luggage>().setColorSuitcase();
           
            LuggageIdentfier.GetComponent<bubbleGoalScript>().setSuitCaseColour();
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
        
    }


 
    [System.Obsolete]
    public void SendData()
    {
        GameState data = new GameState { sessionId = randSession, shotsFired = Shots_Fired, shotsHit = Shots_hit };//score= Evaluation_Score

        string jsonData = JsonUtility.ToJson(data);
        StartCoroutine(AnalythicManager.PostMethod(jsonData));
    }

}
