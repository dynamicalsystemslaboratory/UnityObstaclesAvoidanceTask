using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class vibrationManager : MonoBehaviour
{
    public static vibrationManager singleton;
    // Start is called before the first frame update
    void Start()
    {

        if (singleton && singleton != this)
            Destroy(this);
        else
            singleton = this;
    }



    public void TriggerVibration(int iteration, int frequency, int strength)
    {
        OVRHapticsClip clip = new OVRHapticsClip();
        for(int i = 0; i<iteration; i++)
        {
            clip.WriteSample(i % frequency == 0 ? (byte)strength : (byte)0);
        }

            OVRHaptics.LeftChannel.Preempt(clip);
            OVRHaptics.RightChannel.Preempt(clip);
            print("vibrating");

    }

}
