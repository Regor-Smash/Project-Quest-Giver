using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    private Queue<string> dialogueQueue = new Queue<string>();
    private string[] enterLines = new string[0];
    private string[] exitLines = new string[0];

    public TextMeshProUGUI dialogueText;
    public GameObject dialogueBox;

    public static DialogueManager Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Debug.Log("Instance already set.", Instance);
        }
    }

    void Start()
    {
        //StartDialogue("Test Dialogue");
    }

    private void GetDialogue(string actName)
    {
        if(actName.ToLower() == "entering line" || actName.ToLower() == "enter line")
        {
            dialogueQueue.Enqueue(GetEnteringLine());
            return;
        }
        if(actName.ToLower() == "exiting line" || actName.ToLower() == "exit line")
        {
            dialogueQueue.Enqueue(GetExitingLine());
            return;
        }

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

    private string GetEnteringLine()
    {
        if (enterLines.Length == 0)
        {
            enterLines = DialogueImporter.ImportEnterLines();
        }
        return enterLines[Random.Range(0, enterLines.Length)];
    }

    private string GetExitingLine()
    {
        if (exitLines.Length == 0)
        {
            exitLines = DialogueImporter.ImportExitLines();
        }
        return exitLines[Random.Range(0, exitLines.Length)];
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

    private void OnDestroy()
    {
        Instance = null;
    }
}
