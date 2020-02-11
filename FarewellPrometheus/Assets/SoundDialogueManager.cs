using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundDialogueManager : MonoBehaviour
{
    private AkSwitch Switch;
    public void DialogueTriggerSwitch()
    {
        Debug.Log(Switch + "switch set");
        AkSoundEngine.SetSwitch(, Switch, gameObject);
        AkSoundEngine.PostEvent("Volga_Dial_P1", gameObject);
    }
}
