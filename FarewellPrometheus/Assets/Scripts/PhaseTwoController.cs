using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PhaseTwoController : MonoBehaviour
{
    public Text displayText;
    public InputAction[] inputActions;
    public GameObject image;
    public int roomNumber = 0;

    [HideInInspector] public RoomNavigation roomNavigation;
    [HideInInspector] public List<string> interactionDescriptionsInRoom = new List<string>();

    List<string> actionLog = new List<string>();
    // Start is called before the first frame update
    void Awake()
    {
        roomNavigation = GetComponent<RoomNavigation>();
        //roomNavigation.currentRoom.roomName  pour chopper le nom
    }

    void Start()
    {
        DisplayRoomText();

        DisplayLoggedText();

    }

    public void DisplayLoggedText()
    {
        string logAsText = string.Join("\n", actionLog.ToArray());

        displayText.text = logAsText;
    }

    public void DisplayRoomText()
    {
        ClearCollectionsForNewRoom();

        UnpackRoom();

        string joinedInteractionDescriptions = string.Join("\n", interactionDescriptionsInRoom.ToArray());

        string combinedText = roomNavigation.currentRoom.description + "\n" + joinedInteractionDescriptions;

        LogStringWithReturn(combinedText);
    }

   /* public void DisplayImage()
    {

        if (roomNavigation.currentRoom.roomName == "clairiere")
        {
            image.SetActive(true);

        }
        else image.SetActive(false);
        Debug.Log(roomNavigation.currentRoom.roomName);
    }*/
    void UnpackRoom()
    {
        roomNavigation.UnpackExitsInRoom();
    }

    void ClearCollectionsForNewRoom()
    {
        interactionDescriptionsInRoom.Clear();
        roomNavigation.ClearExits();
        roomNumber += 1;
    }
    public void LogStringWithReturn(string stringToAdd)
    {
        actionLog.Add(stringToAdd + "\n");
    }
    // Update is called once per frame
    void Update()
    {
        //DisplayImage();
    }
}
