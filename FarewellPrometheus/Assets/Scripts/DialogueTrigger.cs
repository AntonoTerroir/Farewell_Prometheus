using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Script a placer sur l'objet qui trigger le dialogue
public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;
   

    public void TriggerDialogue() //trouver le dialmanager et lancer une fonction dessus pour afficher le dialogue
    {
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue); 
    }
   

}
