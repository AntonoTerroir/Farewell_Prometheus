using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AK.Wwise;

public class UI_Button_Sound : MonoBehaviour
{
    public AK.Wwise.Event clickEvent;

    public void OnClick()
    {
        clickEvent.Post(gameObject);
    }

    public AK.Wwise.Event hoverEvent;

    public void OnHover()
    {
        hoverEvent.Post(gameObject);
    }

    //public AK.Wwise.Switch dialogueSwitch;
    /*public string SwitchGroup = "Volga_Dial_P1";
    public string Switch;
    public void DialogueTriggerSwitch()
    {
        Debug.Log(Switch + "switch set");
        AkSoundEngine.SetSwitch(SwitchGroup, Switch, gameObject);
        AkSoundEngine.PostEvent("Volga_Dial_P1", gameObject);
    }*/

    public string StateGroup = "Volga_Dial_P1";
    public string State;
    public void DialogueTriggerSwitch()
    {
        Debug.Log(State + "state set");
        AkSoundEngine.SetState(StateGroup, State);
        AkSoundEngine.PostEvent("Volga_Dial_P1", gameObject);
    }
}
