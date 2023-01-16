using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class CalculateScore : MonoBehaviour
{
    public int Shots_Fired;
    public int Shots_hit;
    public int Shots_Missed;
    public GameObject luggage;
    public int Evaluation_Score;
    // Start is called before the first frame update
    void Update()
    {
        Shots_Fired = luggage.gameObject.GetComponent<Luggage>().shotsFiredData;
        Shots_hit = luggage.gameObject.GetComponent<collision>().shotsHit;
        if(Shots_Fired!=0&&Shots_hit!=0)
        {
            Shots_Missed = Mathf.RoundToInt(Shots_hit / Shots_Fired);
            Evaluation_Score = Mathf.RoundToInt(Shots_Fired / Shots_Missed);
        }
     

        if(Shots_hit > 3)
        {
            SceneManager.LoadScene("WinScene");
        }
       
    }

   

}
