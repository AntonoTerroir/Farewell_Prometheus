using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundDialogueManager : MonoBehaviour
{
    public void DialogueTriggerSwitch01()
    {
        Debug.Log("01 switch set");
        AkSoundEngine.SetSwitch("Volga_Dial_P1", "P1_01", gameObject);
        AkSoundEngine.PostEvent("Volga_Dial_P1", gameObject);
    }
    public void DialogueTriggerSwitch02()
    {
        Debug.Log("02 switch set");
        AkSoundEngine.SetSwitch("Volga_Dial_P1", "P1_02", gameObject);
        AkSoundEngine.PostEvent("Volga_Dial_P1", gameObject);
    }
    public void DialogueTriggerSwitch03()
    {
        Debug.Log("03 switch set");
        AkSoundEngine.SetSwitch("Volga_Dial_P1", "P1_03", gameObject);
        AkSoundEngine.PostEvent("Volga_Dial_P1", gameObject);
    }
    public void DialogueTriggerSwitch04()
    {
        Debug.Log("04 switch set");
        AkSoundEngine.SetSwitch("Volga_Dial_P1", "P1_04", gameObject);
        AkSoundEngine.PostEvent("Volga_Dial_P1", gameObject);
    }
    public void DialogueTriggerSwitch05()
    {
        Debug.Log("05 switch set");
        AkSoundEngine.SetSwitch("Volga_Dial_P1", "P1_05", gameObject);
        AkSoundEngine.PostEvent("Volga_Dial_P1", gameObject);
    }
    public void DialogueTriggerSwitch06()
    {
        Debug.Log("06 switch set");
        AkSoundEngine.SetSwitch("Volga_Dial_P1", "P1_06", gameObject);
        AkSoundEngine.PostEvent("Volga_Dial_P1", gameObject);
    }
    public void DialogueTriggerSwitch07()
    {
        Debug.Log("07 switch set");
        AkSoundEngine.SetSwitch("Volga_Dial_P1", "P1_07", gameObject);
        AkSoundEngine.PostEvent("Volga_Dial_P1", gameObject);
    }
    public void DialogueTriggerSwitch08()
    {
        Debug.Log("08 switch set");
        AkSoundEngine.SetSwitch("Volga_Dial_P1", "P1_08", gameObject);
        AkSoundEngine.PostEvent("Volga_Dial_P1", gameObject);
    }
    public void DialogueContinue()
    {
        AkSoundEngine.PostEvent("Volga_Dial_P1", gameObject); //lance le son de dialogue suivant
    }

    /*public void DialogueStop()
    {
        AkSoundEngine.PostEvent("Volga_Dial_Stop_All", gameObject);  //arrête le son du dialogue en cours
    }*/
}
