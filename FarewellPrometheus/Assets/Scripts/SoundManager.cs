using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    void Start()
    {
        AkSoundEngine.SetState("Stasis_or_Awake", "Stasis");
        AkSoundEngine.PostEvent("Ship_Music", gameObject);
        AkSoundEngine.PostEvent("Ambiance_Bed", gameObject);
    }

    void Update()
    {
        
    }

    public void StartButtonSound()
    {
        AkSoundEngine.SetState("Stasis_or_Awake", "Awake");
    }

    public void PostitHandle()
    {
        AkSoundEngine.PostEvent("Post_it_Handle", gameObject);
    }
}
