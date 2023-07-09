using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public static class PlayerStats
{
    private static float demonicGrasp = 0;
    private static float guildSuspicion = 0;
    private const float deathThreshold = 100;

    public static int daysSurvived { get; private set; }
    public static int questsSucceeded { get; private set; }
    public static int questsFailed { get; private set; }

    public static float Stress { get { return demonicGrasp + guildSuspicion; } }

    public static void Upkeep(float deltaDemon, float deltaSus)
    {
        demonicGrasp += deltaDemon;
        guildSuspicion += deltaSus;

        if(demonicGrasp > deathThreshold)
        {
            SceneManager.LoadScene("Scenes/Endings/Demonic Ending");
        }
        if(guildSuspicion > deathThreshold)
        {
            SceneManager.LoadScene("Scenes/Endings/Suspicion Ending");
        }
    }

    public static void AnotherDaySurvived()
    {
        daysSurvived++;
    }

    public static float DemonPercent()
    {
        return demonicGrasp / deathThreshold;
    }

    public static float SuspicionPercent()
    {
        return guildSuspicion / deathThreshold;
    }
}
