using System.Collections.Generic;

public struct Quest
{
    public string questName;
    public uint level;
    public float demonicInfluence;
    //public uint travelTime;
    public bool urgent;
    public string[] positiveKeywords;
    public string[] negativeKeywords;

    private static readonly Dictionary<ChanceTiers, float> chanceTiers = new Dictionary<ChanceTiers, float>{
            { ChanceTiers.Impossible, 0.0f }, { ChanceTiers.NotLikely, 0.3f }, { ChanceTiers.Probably, 0.75f}, 
            { ChanceTiers.VeryLikely, 0.9f }, { ChanceTiers.Guaranteed, 1f }
        };

    public Quest(QuestSO so)
    {
        this.questName = so.questName;
        this.level = so.level;
        this.demonicInfluence = so.demonicInfluence;
        //this.travelTime = so.travelTime;
        this.urgent = so.urgent;
        this.positiveKeywords = so.positiveKeywords;
        this.negativeKeywords = so.negativeKeywords;
    }

    public ChanceTiers GetSuccessTier (Party party)
    {
        int diff =  (int)party.PartyLevel() - (int)level;

        switch (diff)
        {
            case <= -5: return ChanceTiers.Impossible; //party is 5 or more levels below
            case <= -1: return ChanceTiers.NotLikely;  //party is between 4 and 2 levels below
            case <= 1: return ChanceTiers.Probably;    //party is between 1 level below and 1 level above
            case <= 4: return ChanceTiers.VeryLikely; //party is between 2 and 4 levels above
            default: return ChanceTiers.Guaranteed;    //party is 5 or more levels above
        }
    }

    private float SuccessChance(ChanceTiers tier)
    {
        return chanceTiers[tier];
    }

    public float GetSuccessChance (Party party)
    {
        return SuccessChance(GetSuccessTier(party));
    }
}
