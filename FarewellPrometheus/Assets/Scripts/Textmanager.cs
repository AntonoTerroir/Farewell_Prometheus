using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Textmanager : MonoBehaviour
{
    public GameObject getdirection;
    public Text textBox;
    public InputField userText;
    private string userDirection, go;
    public DialogueTrigger textTrigger;
    private Queue<string> sentences;


    // Start is called before the first frame update
    void Start()
    {
        sentences = new Queue<string>();
    }

    public void StartText(Dialogue dialogue)
    {
        sentences.Clear();

        foreach(string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextText();
    }

    public void DisplayNextText()
    {
        if (sentences.Count == 0)
        {
            Debug.Log("Plus de texte affichable");
        }

        string sentence = sentences.Dequeue();

        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }

    IEnumerator TypeSentence(string sentence)
    {
        textBox.text = " ";

        foreach (char letter in sentence) //isoler les lettres pour les mettre une a une pour apparaitre petit à petit avec un delai
        {
            textBox.text += letter;
            yield return new WaitForSeconds(.02f);

        }
    }

    public void CheckOrder()
    {
        textTrigger = GetComponent<DialogueTrigger>();
        go = "go";
        userDirection = getdirection.GetComponent<Text>().text;

        if (go == userDirection)
        {
            StartText(textTrigger.dialogue);
        }

    }



}
