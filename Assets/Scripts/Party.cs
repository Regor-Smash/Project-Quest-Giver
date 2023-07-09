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

    public bool IsEmpty()
    {
        if(adventurer1 != null)
        {
            return false;
        }
        if (adventurer2 != null)
        {
            return false;
        }
        if (adventurer3 != null)
        {
            return false;
        }
        return true;
    }

    public uint PartyLevel()
    {
        if (IsEmpty())
        {
            Debug.LogError("Party is empty");
            return 0;
        }
        float totLevel = 0;
        int totNum = 0;
        if (adventurer1 != null)
        {
            totLevel += adventurer1.level;
            totNum++;
        }
        else
        {
            totLevel -= 1;
        }
        if (adventurer2 != null)
        {
            totLevel += adventurer2.level;
            totNum++;
        }
        else
        {
            totLevel -= 1;
        }
        if (adventurer3 != null)
        {
            totLevel += adventurer3.level;
            totNum++;
        }
        else
        {
            totLevel -= 1;
        }

        float avg = totLevel / totNum;
        return (uint)Mathf.Clamp(Mathf.RoundToInt(avg), 0, 30);
    }

    public override string ToString()
    {
        if (IsEmpty())
        {
            return "Empty Party";
        }
        else
        {
            string result = $"{adventurer1.adventurerName} ({adventurer1.adventureClass} {adventurer1.level})";
            if (adventurer2 != null)
            {
                result += $", {adventurer2.adventurerName} ({adventurer2.adventureClass} {adventurer2.level})";
            }
            if (adventurer3 != null)
            {
                result += $", {adventurer3.adventurerName} ({adventurer3.adventureClass} {adventurer3.level})";
            }
            return result;
        }
    }
}
