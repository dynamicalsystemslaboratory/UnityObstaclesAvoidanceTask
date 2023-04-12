using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class score_store : MonoBehaviour
{
    // Start is called before the first frame update
    int minute;
    int second;
    int total1;
    int wrong;
    int total2;
    int total3;
    public Text score1;
    public Text score2;
    public Text score3;

    void Start()
    {
        minute = PlayerPrefs.GetInt("minutepast");
        second = PlayerPrefs.GetInt("secondspast");
        wrong = PlayerPrefs.GetInt("Wrong");
        total1 = minute * 60 + second;
        total2 = wrong;
       // total3 = total1 + total2 * 10;
    }

    // Update is called once per frame
    void Update()
    {
        if (minute >= 2 && second >= 2)
        {
            score1.text = minute.ToString() + " Minutes";
            score3.text = second.ToString() + " Seconds";
        }
        else if (minute < 2 && second >= 2)
        {
            score1.text = minute.ToString() + " Minute";
            score3.text = second.ToString() + " Seconds";
        }
        else if (minute >= 2 && second < 2)
        {
            score1.text = minute.ToString() + " Minutes";
            score3.text = second.ToString() + " Second";
        }
        else
        {
            score1.text = minute.ToString() + " Minute";
            score3.text = second.ToString() + " Second";
        }



        score2.text = total2.ToString();
        //Score.text = total3.ToString() + " Seconds";
    }
}
