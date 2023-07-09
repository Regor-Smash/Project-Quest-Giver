using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartyManager : MonoBehaviour
{
    [SerializeField]
    private Walker partyGO;

    private const int averageWait = 10; //in seconds

    public static PartyManager Instance;

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

    private void Start()
    {
        Invoke(nameof(SendIn), 2f);
        QuestGiving.Instance.SelectedQuest.AddListener(SendAway);
    }

    public void SendAway()
    {
        partyGO.WalkToNext(true);
        DialogueManager.Instance.StartDialogue("Exit Line");
        float randWait = Random.Range(averageWait * 0.75f, averageWait * 1.25f);
        Invoke(nameof(SendIn), randWait);
    }
    public void SendIn()
    {
        partyGO.gameObject.SetActive(true);
        partyGO.WalkToNext(false);
        DialogueManager.Instance.StartDialogue("Enter Line");
        QuestGiving.Instance.DisplayQuestContracts();
    }

    private void OnDestroy()
    {
        Instance = null;
    }
}
