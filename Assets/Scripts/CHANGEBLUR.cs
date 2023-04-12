using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CHANGEBLUR : MonoBehaviour
{
    // Start is called before the first frame update

    bool flag= true;

    void Start()
    {
        
        StartCoroutine("WaitAndExecute");
        Invoke("StopExecution", 45.0f);
    }

    void StopExecution()
    {
        flag = false;
    }



    // Update is called once per frame
    void Update()
    {
        
    }


    IEnumerator WaitAndExecute()
    {
        yield return new WaitForSeconds(1f);
        print("print");
        if (flag == true)
        {
            RapidBlurEffect.ChangeValue2 += 0.06f;
            RapidBlurEffect.ChangeValue3 += 0.06f;
        }

        StartCoroutine("WaitAndExecute");

    }
}
