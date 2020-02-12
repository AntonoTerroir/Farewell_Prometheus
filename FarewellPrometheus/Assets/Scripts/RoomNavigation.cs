using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomNavigation : MonoBehaviour
{
    public Room currentRoom;
    

    Dictionary<string, Room> exitDictionary = new Dictionary<string, Room>(); //liste contenant les mots de sorties
    PhaseTwoController controller;

     void Awake()
    {
        controller = GetComponent<PhaseTwoController>();
    }

    public void UnpackExitsInRoom() //accès aux mots de sorties
    {
        for (int i = 0; i < currentRoom.exits.Length; i++)
        {
            exitDictionary.Add(currentRoom.exits[i].keyString, currentRoom.exits [i].valueRoom);
            controller.interactionDescriptionsInRoom.Add(currentRoom.exits[i].exitDescription);

        }
    }

   public void AttemptToChangeRooms(string directionNoun) // sert à changer de room/écran
    {
        if (exitDictionary.ContainsKey(directionNoun)) //si le dico contient le mot clé
        {
            currentRoom = exitDictionary[directionNoun]; //cherche les termes de sorties possibles
            controller.LogStringWithReturn(directionNoun + " effectué"); //affiche que l'action s'est effectuée
            controller.DisplayRoomText();
        }else
        {
            controller.LogStringWithReturn("Impossible de lancer " + directionNoun); //action non effectuée
        }
    }

    public void ClearExits()//fonction pour clear le dico existant pour que celui de la salle suivante se mette
    {
        
        exitDictionary.Clear();
    }
}
