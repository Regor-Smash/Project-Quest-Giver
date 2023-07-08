using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    private float demonicGrasp = 0;
    private float guildOversight = 0;

    private float Stress { get { return demonicGrasp + guildOversight; } }

    public void Upkeep()
    {
        if(Stress > 100)
        {
            //You die
        }
    }
}
