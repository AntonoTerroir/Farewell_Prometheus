using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DescriptionManager : MonoBehaviour
{
    public Text descriptionText;
    private Queue<string> descriptions;
    public DescriptionTrigger destrig;
    public GameObject loginrobot, clairiere, jungle, riviere,camp;
    public InputField orderfield;
    private string[] orders = new string[] {"nord","sud","est","ouest","scan" };
   // private string[] zoneName = new string[] { "clairiere", "jungle", "riviere", "camp" };
    private string getorder;
    public string descName;
    private int i = 0;


   
    void Start()
    {
        descriptions = new Queue<string>(); 

    }

    public void StartDescription(Description description)
    {
        descName = description.name;

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


    //order 0 nord   1 sud    2 est   3 ouest   4 scan
    public void CheckOrder()
    {
        getorder = orderfield.GetComponent<InputField>().text.ToLower();

        if (descName == "loginrobot")//ecran tuto commande robot
        {
            
            if (getorder == orders[4])//order 4 c'est scan
            {
                
                destrig = clairiere.GetComponent<DescriptionTrigger>();
                StartDescription(destrig.description);
                CleanSelectInput();
                
            }else
            {
                CleanSelectInput();
                DisplayErrorOrder();
            }
        }else if (descName == "cl") //ecran clairiere
        {
            if (getorder == orders[0])
            {
                destrig = jungle.GetComponent<DescriptionTrigger>();
                StartDescription(destrig.description);
                CleanSelectInput();

            }else
            {
                CleanSelectInput();
                DisplayErrorOrder();
            }

            /* if (getorder == orders[2])
             {

                 destrig = loginrobot.GetComponent<DescriptionTrigger>();
                 StartDescription(destrig.description);
                 CleanSelectInput();

             }*/
        }
        else if (descName == "jg")//ecran jungle
        {
            if (getorder == orders[3])//ouest
            {
                destrig = riviere.GetComponent<DescriptionTrigger>();
                StartDescription(destrig.description);
                CleanSelectInput();

            }else if (getorder == orders[1])
            {
           
                destrig = clairiere.GetComponent<DescriptionTrigger>();
                StartDescription(destrig.description);
                CleanSelectInput();

            }else
            {
                CleanSelectInput();
                DisplayErrorOrder();
            }
        }
        else if (descName == "rv")//ecran riviere
        {
            if (getorder == orders[0])//nord
            {
                destrig = camp.GetComponent<DescriptionTrigger>();
                StartDescription(destrig.description);
                CleanSelectInput();

            }else if (getorder == orders[2])
            {

                destrig = jungle.GetComponent<DescriptionTrigger>();
                StartDescription(destrig.description);
                CleanSelectInput();

            } else
            {
                CleanSelectInput();
                DisplayErrorOrder();
            }
        }
        else if (descName == "cp")//ecran camp
        {
            if (getorder == orders[1])//sud
            {
                destrig = riviere.GetComponent<DescriptionTrigger>();
                StartDescription(destrig.description);
                CleanSelectInput();

            }
            else if (getorder == orders[4])
            {

                destrig = jungle.GetComponent<DescriptionTrigger>();
                StartDescription(destrig.description);
                CleanSelectInput();

            }
            else
            {
                CleanSelectInput();
                DisplayErrorOrder();
            }
        }
    }



    public void CleanSelectInput()
    {
        orderfield.Select();
        orderfield.text = "";
        getorder = "";
        orderfield.ActivateInputField();
    }

    public void DisplayErrorOrder()
    {
        CleanSelectInput();
        descriptionText.text = descriptionText.text + "\n commande invalide";
    }

}
