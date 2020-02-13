using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DescriptionManager : MonoBehaviour
{
    public Text descriptionText;
    private Queue<string> descriptions;
    public DescriptionTrigger destrig;
    public GameObject loginrobot, clairiere, jungle;
    public Text orderfield;
    private string[] orders = new string[] {"nord","sud","scan" };
    private string getorder;
    private int i = 0;


   
    void Start()
    {
        descriptions = new Queue<string>(); 

    }

    public void StartDescription(Description description)
    {
        descriptions.Clear();

        foreach (string descline in description.descriptions)
        {
            descriptions.Enqueue(descline);
        }

        DisplayNextDescline();

    }

    public void DisplayNextDescline()
    {
        if (descriptions.Count == 0)
        {
            EndDescription();
            
            return;
        }else
        {
           // GameObject.Find("SoundDialogueButton").GetComponent<SoundDialogueManager>().DialogueContinue();
        }

        string descline = descriptions.Dequeue();

        StopAllCoroutines();
        StartCoroutine(TypeSentence(descline));
    }

    IEnumerator TypeSentence(string descline)
    {
        descriptionText.text = " ";

        foreach (char letter in descline) //isoler les lettres pour les mettre une a une pour apparaitre petit à petit avec un delai
        {
            descriptionText.text += letter;
            yield return new WaitForSeconds(.02f);

        }
    }

    public void EndDescription()
    {
        Debug.Log("End of description");
    }

    public void CheckOrder()
    {
        getorder = orderfield.GetComponent<Text>().text;
        
       // if (loginrobot)
       // {
            if (getorder == orders[2] )
            {
               // loginrobot.SetActive(false);
                destrig = clairiere.GetComponent<DescriptionTrigger>();
                StartDescription(destrig.description);
            }
        //}
    }



}
