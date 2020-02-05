using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
}
