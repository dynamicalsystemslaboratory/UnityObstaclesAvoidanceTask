using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scoreNormal : MonoBehaviour
{
    // Start is called before the first frame update
    int minute;
    int second;
    int total1;
    int collide;
    int total2;
    int total3;
    public Text score1;
    public Text score2;
    public Text Score;
    void Start()
    {
        minute =  PlayerPrefs.GetInt("minuteNormal");
        second = PlayerPrefs.GetInt("secondsNormal");
        collide = PlayerPrefs.GetInt("collisionNormal");
        total1 = minute * 60 + second;
        total2 = collide;
        total3 = total1 + total2 * 10;
    }

    // Update is called once per frame
    void Update()
    {
        score1.text = total1.ToString() +" Seconds";
        score2.text = total2.ToString()+ " * 10";
        Score.text = total3.ToString()+ " Seconds";
    }
}
