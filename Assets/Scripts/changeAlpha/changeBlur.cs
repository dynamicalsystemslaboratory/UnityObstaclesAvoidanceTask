using UnityEngine;
using System.Collections;

public class changeBlur : MonoBehaviour {




    float transitionTime = 10f; // Amount of time it takes to fade between colors
    float SizeNum = 0.0f;
    private bool flag;
    public Material myMaterial;


    void Start()
    {

        Invoke("StartExecution", 0f);
       
        Invoke("StopExecution", 30f);
        flag = true;
    }

    void Update()
    {

        myMaterial.SetFloat("_Size", SizeNum);
    }


    void StopExecution()
    {
        flag = false;
    }
    void StartExecution()
    {
        StartCoroutine("ColorChange");
    }



    IEnumerator ColorChange()

    {


        //yield return new WaitForSeconds(10f);

        //Create and set transitionRate to 0. This is necessary for our next while loop to function

        /* 1 is the highest value that the Color.Lerp function uses for

         * transitioning between two colors. This while loop will execute

         * until transitionRate is incremented to 1 or higher

         */
        yield return new WaitForSeconds(2f);
        print("changing");
        //this next line is how we change our material color property. We Lerp between the current color and newColor
        if (flag == true)
        {
            SizeNum += 0.03f;
        }
        StartCoroutine("ColorChange");


        // Increment transitionRate over the length of transitionTime

        yield return null; // wait for a frame then loop again

            }



      
    }

    

