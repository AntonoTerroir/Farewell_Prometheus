using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    void Start()
    {
        AkSoundEngine.SetState("Music", "Title");
        AkSoundEngine.SetState("Location", "None");
        AkSoundEngine.PostEvent("Ambience_Event", gameObject);
    }

    public void MusicStart()
    {
        AkSoundEngine.PostEvent("Music_Event", gameObject);
    }

    public void AmbienceStart()
    {
        AkSoundEngine.SetState("Location", "VS1");
        AkSoundEngine.SetState("Music", "Stasis");
    }

    public void StartButtonSound()
    {
        AkSoundEngine.SetState("Music", "Awake");
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
