using UnityEngine;

public static class PartyGenerator
{
    public static readonly int classNum = System.Enum.GetNames(typeof(AdventurerClasses)).Length;

    private const float singlePartyChance = 0.05f;
    private const float douPartyChance = 0.35f;

    private static uint RandomLevel(uint medianLevel)
    {
        return (uint)Mathf.Clamp(Random.Range(medianLevel - 1, medianLevel + 1), 1, 20);
    }

    private static Adventurer GenerateNewAdventurer(uint targetLevel)
    {
        string adName = Adventurer.RandomName();
        AdventurerClasses adClass = (AdventurerClasses)Random.Range(0, classNum);
        uint level = RandomLevel(targetLevel);
        string[] secKeywords = new string[] { "Holy" };

        return new Adventurer(adName, adClass, level, secKeywords);
    }

    public static Party GenerateNewParty(uint targetLevel)
    {
        Adventurer advent1 = GenerateNewAdventurer(targetLevel);
        if(Random.Range(0.0f, 1.0f) < singlePartyChance)
        {
            return new Party(advent1);
        }

        Adventurer advent2 = GenerateNewAdventurer(targetLevel);
        if (Random.Range(0.0f, 1.0f) < douPartyChance)
        {
            return new Party(advent1, advent2);
        }

        Adventurer advent3 = GenerateNewAdventurer(targetLevel);
        return new Party(advent1, advent2, advent3);
    }
}
