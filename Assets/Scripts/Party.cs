using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Party
{
    public readonly Adventurer adventurer1;
    public readonly Adventurer adventurer2;
    public readonly Adventurer adventurer3;

    public Party(Adventurer a1, Adventurer a2 = null, Adventurer a3 = null)
    {
        this.adventurer1 = a1;
        this.adventurer2 = a2;
        this.adventurer3 = a3;
    }

    public uint PartyLevel()
    {
        float totLevel = 0;
        int totNum = 0;
        if (adventurer1 != null)
        {
            totLevel += adventurer1.level;
            totNum++;
        }
        if (adventurer2 != null)
        {
            totLevel += adventurer2.level;
            totNum++;
        }
        if (adventurer3 != null)
        {
            totLevel += adventurer3.level;
            totNum++;
        }

        if (totNum > 0)
        {
            float avg = totLevel / totNum;
            return (uint)Mathf.Abs(Mathf.RoundToInt(avg));
        }
        else
        {
            Debug.LogError("Party is empty");
            return 0;
        }
    }
}
