using UnityEngine;

public class AcceptedQuest
{
    public Quest quest;
    public Party party;

    private const float unitOfSuspicion = 10; //basic amount of suspicion raised by failing a quest

    public AcceptedQuest(Quest _quest, Party _party)
    {
        quest = _quest;
        party = _party;
    }

    private static float susByTier(ChanceTiers t)
    {
        switch (t)
        {
            case ChanceTiers.Impossible: return 20f;
            case ChanceTiers.NotLikely: return 10f;
            case ChanceTiers.Probably: return -10f;
            case ChanceTiers.VeryLikely: return -5f;
            case ChanceTiers.Guaranteed: return 5f;
            default: return 0f;
        }
    }

    public void Finish()
    {
        float qChance = quest.GetSuccessChance(party);
        bool success = Random.Range(0.0f, 1.0f) < qChance;

        ChanceTiers tier = quest.GetSuccessTier(party);

        PlayerStats.AnotherQuestCompleted(success);
        if (success)
        {
            if(quest.questName == "Demon Lord's Keep")
            {
                UnityEngine.SceneManagement.SceneManager.LoadScene("Scenes/Endings/Heroic Ending");
            }
            PlayerStats.Upkeep(quest.demonicInfluence, susByTier(tier));
        }
        else
        {
            PlayerStats.Upkeep(-quest.demonicInfluence, susByTier(tier));
        }
    }
}
