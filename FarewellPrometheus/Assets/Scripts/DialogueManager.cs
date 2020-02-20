using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public Text nameText;
    public Text dialogueText;
    private Queue<string> sentences; //queue c'est comme list mais ça charge différement, contient les dialogues
    public Animator animator,volgaAnim;
    public int choicenumber = 0, a = 0, b = 0, c = 0, d = 0, errorpass = 0, volga; // en public pour debug
    public GameObject continuebutton, inputpassword, login;
    public DialogueTrigger dialtrig;
    private string password, getpassword;
    public InputField inputfieldpassword;
    public Animator camera;
    
    // Start is called before the first frame update
    void Start()
    {
        sentences = new Queue<string>(); //initialisation de sentences
    }
    
    public void StartDialogue(Dialogue dialogue) //lancer dialogue indiqué
    {
    
        animator.SetBool("IsOpen", true);
        animator.SetBool("IsOpen2", false);

        nameText.text = dialogue.name;
        volga = dialogue.volgaFace;
        volgaAnim.SetInteger("volgaface", volga);

        sentences.Clear(); //clear les phrases deja presentes

        foreach (string sentence in dialogue.sentences )
        {
            sentences.Enqueue(sentence); //on met les sentences dans la variable locale sentence pour les "precharger"
        }

        DisplayNextSentence();

    }

    public void DisplayNextSentence()
    {
        animator.SetBool("IsOpen", false);//anim apparition bouton choix dial
        animator.SetBool("IsOpen2", false);
        animator.SetBool("IsOpen3", false);
        animator.SetBool("IsOpen4", false);
        if (sentences.Count == 0)
        {
            
            continuebutton = GameObject.Find("ContinueButton");
            continuebutton.SetActive(false); //faire depop le bouton continue quand y a les options de dial/ il revient via interaction unity
    
            EndDialogue();
            return;
        }
        else
        {
            GameObject.Find("SoundDialogueButton").GetComponent<SoundDialogueManager>().DialogueContinue();
        }
        
       
             
        string sentence = sentences.Dequeue(); // on "decharge" la phrase suivante dans sentence pour l'afficher

        
        
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }
    IEnumerator TypeSentence (string sentence)
    {
        dialogueText.text = " ";

        foreach (char letter in sentence) //isoler les lettres pour les mettre une a une pour apparaitre petit à petit avec un delai
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(.02f);

        }
    }

    public void StartVoice()
    {
        /*if (sentences.Count != 0)
        {
            GameObject.Find("SoundDialogueButton").GetComponent<SoundDialogueManager>().DialogueContinue();
        }
        /*else
        {
            AkSoundEngine.PostEvent("Volga_Dial_Stop_All", gameObject);
        }*/

        /*if (sentences.Count == 0)
        {
            GameObject.Find("SoundDialogueButton").GetComponent<SoundDialogueManager>().DialogueStop();
        }*/
        
    }

    public void EndDialogue()
    {
        volgaAnim.SetInteger("volgaface", 0);
        if (choicenumber <= 3)
        {
            animator.SetBool("IsOpen", true);
        }
        else if (choicenumber >= 4 && choicenumber <= 5)
        {
            animator.SetBool("IsOpen2", true);
        } else if (choicenumber == 6)
        {
            animator.SetBool("IsOpen3", true);
            choicenumber += 1;
        }else if (choicenumber == 7)
        {
            animator.SetBool("IsOpen4", true);
        }
        //animator.SetBool("IsOpen", false);
        Debug.Log("End of conv");
        Debug.Log("nombre = " + choicenumber);

    }

    public void CheckPassword() //verification du mdp au debut
    {
        password = "1209"; 
        getpassword = inputpassword.GetComponent<Text>().text; //recuperer le mdp ecrit pas le joueur
        dialtrig = login.GetComponent<DialogueTrigger>(); //recuperer le script pour le lancer au moment du clic valide sur login

        if (getpassword == password) //si c'est ok on masque le login et le champ de mdp et on affiche le continue puis on lance le dialogue
        {
            AkSoundEngine.PostEvent("Password_Right", gameObject);
            continuebutton.SetActive(true); 
            login.SetActive(false);
            inputpassword.SetActive(false);
            StartDialogue(dialtrig.dialogue);

            Debug.Log("Mot de passe ok");
        }
        else //sinon clear le champ de mdp et indique mauvais mdp
        {
            //inputpassword.GetComponent<Text>().text = " "; 
            AkSoundEngine.PostEvent("Password_Wrong", gameObject);
            inputfieldpassword.Select();
            inputfieldpassword.text = "";
            if (errorpass >= 0)
            {
                dialogueText.text = "Mot de passe non reconnu \n Indice : anniversaire maman";
                inputfieldpassword.ActivateInputField();
            }
            else
            {
                dialogueText.text = "Mot de passe non reconnu";
                errorpass += 1;
                inputfieldpassword.ActivateInputField();
            }
            Debug.Log("Mot de passe pas ok");
        }
        
    }


    //Fonctions pour incrémenter et garder en mémoire les choix de dial
    public void ButtonWhere()
    {
        if (a == 0)
        {
            choicenumber += 1;
            a = 1;
        }
    }
    public void ButtonWho()
    {
        if (b == 0)
        {
            choicenumber += 1;
            b = 1;
        }
    }
    public void ButtonGoal()
    {
        if (c == 0)
        {
            choicenumber += 1;
            c = 1;
        }
    }
    public void ButtonSpeak()
    {
        if (d == 0)
        {
            choicenumber += 1;
            d = 1;
        }
    }
    public void ButtonAnalyse()
    {
        if (a == 1)
        {
            choicenumber += 1;
            a = 2;
        }
    }
    public void ButtonShip()
    {
        if (b == 1)
        {
            choicenumber += 1;
            b = 2;
        }
    }

    public void PanCam()
    {
        camera.SetBool("pan", true);
       
    }

    public void ButtonRobotDisappear()
    {
        animator.SetBool("IsOpen4", false);
    }

}
