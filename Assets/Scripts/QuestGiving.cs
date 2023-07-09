using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class QuestGiving : MonoBehaviour
{
    [SerializeField]
    private GameObject contractPrefab;
    public UnityEvent SelectedQuest;

    private Quest[] allQuests;
    private List<GameObject> questContracts = new List<GameObject> ();
    public static List<AcceptedQuest> currentQuests = new List<AcceptedQuest>();
    private const int dailyQuestCount = 5;

    public static QuestGiving Instance;

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
        
        QuestSO[] allQSO = Resources.LoadAll<QuestSO>("Quests");
        allQuests = new Quest[allQSO.Length];
        for(int i = 0; i < allQSO.Length; i++)
        {
            allQuests[i] = new Quest(allQSO[i]);
        }
        //DisplayQuestContracts();
    }

    private void ClearQuestContracts()
    {
        while(questContracts.Count > 0)
        {
            Destroy(questContracts[0]);
            questContracts.RemoveAt(0);
        }
        
    }

    public void DisplayQuestContracts()
    {
        ClearQuestContracts();
        for (int i = 0; i < allQuests.Length; i++)
        {
            GameObject newContract = GameObject.Instantiate(contractPrefab, transform);
            newContract.GetComponent<QuestDisplay>().DisplayQuest(allQuests[i], PartyManager.Instance.currParty);
            questContracts.Add(newContract);
        }
    }

    public void PickQuest(Quest q, Party p)
    {
        currentQuests.Add(new AcceptedQuest(q, p));
        Debug.Log("You picked: " + q.questName);
        SelectedQuest.Invoke();
        ClearQuestContracts();

        if(currentQuests.Count >= dailyQuestCount)
        {
            EndDay();
        }
    }

    private void EndDay()
    {
        SceneManager.LoadScene("Scenes/End of Shift");
    }

    private void OnDestroy()
    {
        Instance = null;
    }
}
