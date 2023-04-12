using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    // Start is called before the first frame update

    //int sceneindex = 4;
    static public bool[] scenecheck = new bool[10];
    public static bool bolflag= true;

    int currentindex;
    public void Normal()
    {
        Debug.Log("normal");
        SceneManager.LoadScene("normal");

    }

   

    public void Amild()
    {
        Debug.Log("mildswitch");
        SceneManager.LoadScene("AMD_mild");

    }
    public void Amedian()
    {
        Debug.Log("medianswitch");
        SceneManager.LoadScene("AMD_median");
       
    }


    public void Asevere()
    {
        Debug.Log("severeswitch");
        SceneManager.LoadScene("AMD_severe");

    }

    public void Dmild()
    {
        Debug.Log("mildswitch");
        SceneManager.LoadScene("Diabetic_mild");

    }
    public void Dmedian()
    {
        Debug.Log("medianswitch");
        SceneManager.LoadScene("Diabetic_median");

    }


    public void Dsevere()
    {
        Debug.Log("severeswitch");
        SceneManager.LoadScene("Diabetic_severe");

    }

    public void Gmild()
    {
        Debug.Log("mildswitch");
        SceneManager.LoadScene("Glau_mild");

    }
    public void Gmedian()
    {
        Debug.Log("medianswitch");
        SceneManager.LoadScene("Glau_median");

    }


    public void Gsevere()
    {
        Debug.Log("severeswitch");
        SceneManager.LoadScene("Glau_severe");

    }

    public void Scene()
    {
        SceneManager.LoadScene("instruction3");
    }

    public void InstructionNormal()
    {
        SceneManager.LoadScene("instruction_normal");
    }

    public void InstructionGlau()
    {
        SceneManager.LoadScene("instruction_glaucoma");
    }

    public void timephaseback()
    {
        SceneManager.LoadScene("time_normal");
    }


    public void timephaseamd()
    {
        SceneManager.LoadScene("time_instrAMD");
    }

    public void timephasediabetic()
    {
        SceneManager.LoadScene("time_instrDB");
    }
    public void timePhaseGlau()
    {
        SceneManager.LoadScene("time_instglau");
    }

    public void finalScore()
    {
        SceneManager.LoadScene("final_score");
    }

    public void glau_instr2()
    {
        SceneManager.LoadScene("instr_glau2");
    }

    public void amdmild_back()
    {
        SceneManager.LoadScene("amd_mild");
    }

    public void storeback()
    {
        SceneManager.LoadScene("storeScene");
    }

    public void activity_store()
    {
        SceneManager.LoadScene("shoppinglist");
    }

    public void activity_3()
    {
        SceneManager.LoadScene("activity_3");
    }

    public void activity_fruit()
    {
        SceneManager.LoadScene("activity_fruit");
    }

    public void activity_amdinfo()
    {
        SceneManager.LoadScene("amdinfo_activity");
    }

    public void activity_drinfo()
    {
        SceneManager.LoadScene("drinfo_activity");
    }

    public void activity_glauinfo()
    {
        SceneManager.LoadScene("Glaucomainfo_activity");
    }

    public void activity_ending()
    {
        SceneManager.LoadScene("activity_ending");
    }


    static public void experiments()
    {
        if (bolflag == true)
        {
            for (int n = 0; n < 10; n++)
            {
                int currentindex = Random.Range(0, 10);
                while (scenecheck[currentindex] == true)
                {
                    currentindex = Random.Range(0, 10);
                    print("same!!");

                }
                // PlayerPrefs.SetInt("index" + n, currentindex);
               // scenecheck[currentindex] = true;
                SceneManager.LoadScene(6 + currentindex);

            }

        }
    }
    static public void end()
    {
        SceneManager.LoadScene(16);
    }

     public void experimentsstart()
    {
        

                int currentindex = Random.Range(0, 10);

               // PlayerPrefs.SetInt("index" + n, currentindex);
                scenecheck[currentindex] = true;
                SceneManager.LoadScene(6 + currentindex);

            

        
    }
    static public void nextscene()
    {
        int current =SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(1+current);
    }

    public void nextscene1()
    {
        int current = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(1 + current);
    }

    public void restart()
    {

        SceneManager.LoadScene(0);
    }
}
