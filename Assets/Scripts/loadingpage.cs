using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class loadingpage : MonoBehaviour
{
    public GameObject center1;
    public GameObject center2;
    public GameObject canvas1;
    public GameObject canvas2;
    int count;
    public Text countdown;
    float start;


    // Start is called before the first frame update
    void Start()
    {
        print(SceneManager.GetActiveScene().buildIndex);
        SceneSwitcher.scenecheck[SceneManager.GetActiveScene().buildIndex-6] = true;
        start = Time.time;
        for (int n = 0; n < 9; n++)
        {
            print(SceneSwitcher.scenecheck[n]);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time- start >= 10f)
        {
            canvas1.SetActive(false);
            canvas2.SetActive(true);
            count=(int)(Time.time - start-10);
            countdown.text = (3 - count).ToString();
        }
        if (Time.time - start >= 13f)
        {
            center1.SetActive(false);
            center2.SetActive(true);

        }
    }
}
