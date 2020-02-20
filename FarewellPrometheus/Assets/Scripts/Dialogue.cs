using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable] //sert à avoir un sous menu dans l'inspector
public class Dialogue //class à utiliser par la suite dans les scripts pour déclarer variable
{
    public string name; //string simple car mot unique
    public int volgaFace;
    [TextArea(3,10)] //resize la taille des boxs de texte dans l'inspector
    public string[] sentences; //array car besoin de multiples mots 
}
