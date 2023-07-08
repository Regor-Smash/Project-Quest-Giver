using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    private Queue<string> dialogueQueue = new Queue<string>();

    public TextMeshProUGUI dialogueText;
    public GameObject dialogueBox;

    void Start()
    {
        //StartDialogue("Test Dialogue");
    }

    private void GetDialogue(string actName)
    {
        string[] dialog = DialogueImporter.ImportDialogueFromName(actName);
        for(int i = 0; i < dialog.Length; i++)
        {
            dialogueQueue.Enqueue(dialog[i]);
        }
        //return dialog;
    }

    public void StartDialogue(string actName)
    {
        if(dialogueQueue.Count == 0)
        {
            GetDialogue(actName);
            if (dialogueQueue.Count > 0)
            {
                dialogueBox.SetActive(true);
                DisplayNextDialogue();
            }
        }
        else
        {
            Debug.LogWarning("Can't start '" + actName + "' dialogue becasue dialogue is already in progress.");
        }
    }

    public void DisplayNextDialogue()
    {
        if(dialogueQueue.Count > 0)
        {
            string t = dialogueQueue.Dequeue();
            if(t == "")
            {
                DisplayNextDialogue();
                return;
            }
            dialogueText.text = t;
        }
        else
        {
            EndDialogue();
        }
    }

    public void EndDialogue()
    {
        dialogueText.text = "";
        dialogueBox.SetActive(false);
    }
}
