using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartyManager : MonoBehaviour
{
    [SerializeField]
    private Walker partyGO;

    private const int averageWait = 6; //in seconds
    public Party currParty;

    public static PartyManager Instance;

    [SerializeField]
    private Sprite rangerSprite;
    [SerializeField]
    private Sprite warriorSprite;
    [SerializeField]
    private Sprite priestSprite;
    [SerializeField]
    private Sprite wizardSprite;

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

    private Party GetRandomParty()
    {
        Party p = PartyGenerator.GenerateNewParty((uint)(Random.Range(2, 11) + PlayerStats.daysSurvived));

        SpriteRenderer[] sprites = partyGO.GetComponentsInChildren<SpriteRenderer>();
        for (int i = 0; i < sprites.Length; i++)
        {
            sprites[i].sprite = GetClassSprite(p.GetClassAt(i));
        }

        return p;
    }

    private Sprite GetClassSprite(AdventurerClasses adClass)
    {
        switch (adClass)
        {
            case AdventurerClasses.Priest: return priestSprite;
            case AdventurerClasses.Warrior: return warriorSprite;
            case AdventurerClasses.Sorcerer: return wizardSprite;
            case AdventurerClasses.Ranger: return rangerSprite;
            default: return null;
        }
    }

    private Party LoadRandomParty()
    {
        AdventurerSO[] adventurers = Resources.LoadAll<AdventurerSO>("Named Adventurers");
        return new Party(new Adventurer(adventurers[0]), new Adventurer(adventurers[1]), new Adventurer(adventurers[2]));
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
        currParty = GetRandomParty();
        Debug.Log(currParty.ToString());

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
