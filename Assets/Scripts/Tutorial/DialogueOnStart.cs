using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueOnStart : MonoBehaviour
{
    [SerializeField]
    private string dialogueName;

    private void Start()
    {
        DialogueManager.Instance.StartDialogue(dialogueName);
    }
}
