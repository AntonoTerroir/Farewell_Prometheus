using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    void Start()
    {
        AkSoundEngine.SetState("Stasis_or_Awake", "Stasis");
        AkSoundEngine.SetState("Location", "VS1");
        AkSoundEngine.PostEvent("Ship_Music", gameObject);
        AkSoundEngine.PostEvent("Ambience_Event", gameObject);
    }

    void Update()
    {
        
    }

    public void StartButtonSound()
    {
        AkSoundEngine.SetState("Stasis_or_Awake", "Awake");
        AkSoundEngine.PostEvent("Computer_Start", gameObject);
    }

    public void PostitHandle()
    {
        AkSoundEngine.PostEvent("Post_it_Handle", gameObject);
    }

    public void SetAmbienceVS1()
    {
        AkSoundEngine.SetState("Location", "VS1");
    }

    public void SetAmbienceCL1()
    {
        AkSoundEngine.SetState("Location", "CL1");
    }
    public void SetAmbienceJG1()
    {
        AkSoundEngine.SetState("Location", "JG1");
    }
}
