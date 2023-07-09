using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestGiving : MonoBehaviour
{
    public GameObject contractPrefab;
    private Party currParty;
    private Quest[] allQuests;

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
        Debug.Log("You picked: " + q.questName);
    }

    private void OnDestroy()
    {
        instance = null;
    }
}
