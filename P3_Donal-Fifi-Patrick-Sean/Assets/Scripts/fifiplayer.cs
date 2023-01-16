using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Net;
using UnityEngine.Networking;

public class fifiplayer : MonoBehaviour
{
    [Header("Server Data")]
    public int randSession;
    public int points1;
    public int points2;


    // Start is called before the first frame update
    void Start()
    {
        //randSession = Random.Range(1, 1000);
        //points1 = Random.Range(1, 10);
        //points2 = Random.Range(1, 10);

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.J))
        {
            //SendData();
        }
    }


    //[System.Obsolete]
    //public void SendData()
    //{
    //    GameState data = new GameState { sessionId = randSession, point1 = points1, point2 = points2 };

    //    string jsonData = JsonUtility.ToJson(data);
    //    StartCoroutine(AnalythicManager.PostMethod(jsonData));
    //}
}
