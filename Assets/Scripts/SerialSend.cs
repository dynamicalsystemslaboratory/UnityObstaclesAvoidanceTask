using UnityEngine;
using System.Collections;
using System.IO.Ports;
using System.Threading;

public class SerialSend : MonoBehaviour
{
    public string port= "/dev/cu.usbmodem142101";
    //public static SerialPort sp = new SerialPort("COM4", 9600, Parity.None, 8, StopBits.One);
    static SerialPort sp;
   // public string message2;
    //int toRead = sp.BytesToRead;
    //public byte[] buffer;
    byte[] ReceiveBuffer = new byte[2048];
    int offset = 0;


    float timePassed = 0.0f;
    // Use this for initialization
    void Start()
    {
        sp =  new SerialPort(port, 9600);
       // toRead = sp.BytesToRead;
        OpenConnection();
    }
    // Update is called once per frame
    void Update()
    {
        //timePassed+=Time.deltaTime;
        //if(timePassed>=0.2f){

        //print("BytesToRead" +sp.BytesToRead);
        try
        {
            //print(sp);
            sp.Read(ReceiveBuffer, offset, sp.BytesToRead);
            offset += sp.BytesToRead;
        }
        catch
        {

        }
        //message2 = sp.ReadLine();
        //print(message2);
        //	timePassed = 0.0f;
        //}
    }

    public void OpenConnection()
    {
        if (sp != null)
        {
            if (sp.IsOpen)
            {
                sp.Close();
                print("Closing port, because it was already open!");
            }
            else
            {
                sp.Open();  // opens the connection
                sp.ReadTimeout = 50;  // sets the timeout value before reporting error
                print("Port Opened!");
                //		message = "Port Opened!";
            }
        }
        else
        {
            if (sp.IsOpen)
            {
                print("Port is already open");
            }
            else
            {
                print("Port == null");
            }
        }
    }



    public static void ledaOn()
    {
        sp.Write("on01");
        sp.Write("A"+DetectionRay.dist2.ToString());
        print("leda");
    }

    public static void ledbOn()
    {
        sp.Write("on02");
        sp.Write("B" + DetectionRay.dist2.ToString());
        print("ledb");
    }

    public static void ledcOn()
    {
        sp.Write("on03");
        print(DetectionRay.dist2.ToString());
        sp.Write("C" + DetectionRay.dist2.ToString());
        print("ledc");
    }

    public static void leddOn()
    {
        sp.Write("on04");
        print(DetectionRay.dist2.ToString());
        sp.Write("D" + DetectionRay.dist2.ToString());
        print("ledd");
    }

    public static void ledeOn()
    {
        sp.Write("on05");
        print(DetectionRay.dist2.ToString());
        sp.Write("E" + DetectionRay.dist2.ToString());
        print("lede");
    }
    public static void ledaOff()
    {
        sp.Write("off1");
    }

    public static void ledbOff()
    {
        sp.Write("off2");
    }

    public static void ledcOff()
    {
        sp.Write("off3");
    }
    public static void leddOff()
    {
        sp.Write("off4");
    }

    public static void ledeOff()
    {
        sp.Write("off5");
    }

    public static void ledaOn1()
    {
        sp.Write("on11");
        print("leda");
    }

    public static void ledbOn1()
    {
        sp.Write("on12");
        print("ledb");
    }

    public static void ledcOn1()
    {
        sp.Write("on13");
        
        print("ledc");
    }

    public static void leddOn1()
    {
        sp.Write("on14");
        print("ledd");
    }

    public static void ledeOn1()
    {
        sp.Write("on15");
        print("lede");
    }
    public static void ledaOff1()
    {
        sp.Write("of11");
    }

    public static void ledbOff1()
    {
        sp.Write("of12");
    }

    public static void ledcOff1()
    {
        sp.Write("of13");
    }
    public static void leddOff1()
    {
        sp.Write("of14");
    }

    public static void ledeOff1()
    {
        sp.Write("of15");
    }


    public static void riftTest()
    {
        sp.Write("test");
    }

    public static void riftTestoff()
    {
        sp.Write("toff");//turn off
    }

}
