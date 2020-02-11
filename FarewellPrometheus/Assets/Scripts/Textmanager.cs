using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Textmanager : MonoBehaviour
{
    public Text textBox;
    public InputField userText;
    private string userDirection;
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
    }


    
    
}
