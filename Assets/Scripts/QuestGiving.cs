using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class QuestGiving : MonoBehaviour
{
    public GameObject contractPrefab;
    public UnityEvent SelectedQuest;
    private Party currParty;
    private Quest[] allQuests;
    private List<AcceptedQuest> currentQuests = new List<AcceptedQuest>();

    public static QuestGiving instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Debug.Log("Instance already set.", instance);
        }
    }

    void Start()
    {
        currParty = GetRandomParty();
        Debug.Log(currParty.ToString());
        QuestSO[] allQSO = Resources.LoadAll<QuestSO>("Quests");
        allQuests = new Quest[allQSO.Length];
        for(int i = 0; i < allQSO.Length; i++)
        {
            allQuests[i] = new Quest(allQSO[i]);
        }
        DisplayQuestContracts();
    }

    private Party GetRandomParty()
    {
        return PartyGenerator.GenerateNewParty((uint)Random.Range(1, 11));
    }

    private Party LoadRandomParty()
    {
        AdventurerSO[] adventurers = Resources.LoadAll<AdventurerSO>("Named Adventurers");
        return new Party(new Adventurer(adventurers[0]), new Adventurer(adventurers[1]), new Adventurer(adventurers[2]));
    }

    public void DisplayQuestContracts()
    {
        for (int i = 0; i < allQuests.Length; i++)
        {
            GameObject newContract = GameObject.Instantiate(contractPrefab, transform);
            newContract.GetComponent<QuestDisplay>().DisplayQuest(allQuests[i], currParty);
        }
    }

    public void PickQuest(Quest q)
    {
        currentQuests.Add(new AcceptedQuest(q, currParty));
        Debug.Log("You picked: " + q.questName);
        SelectedQuest.Invoke();
    }

    private void OnDestroy()
    {
        instance = null;
    }
}


class AcceptedQuest
{
    public Quest quest;
    public Party party;

    public AcceptedQuest(Quest _quest, Party _party)
    {
        quest = _quest;
        party = _party;
    }
}