using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class PlayerStats
{
    private static float demonicGrasp = 10;
    private static float guildSuspicion = 0;
    private const float deathThreshold = 100;

    public static int daysSurvived { get; private set; }
    public static int questsSucceeded { get; private set; }
    public static int questsFailed { get; private set; }

    public static float Stress { get { return demonicGrasp + guildSuspicion; } }

    public static void Upkeep(float deltaDemon, float deltaSus)
    {
        demonicGrasp = Mathf.Clamp(demonicGrasp + deltaDemon, 5f, 150f);
        guildSuspicion = Mathf.Clamp(guildSuspicion + deltaSus, 0f, 150f);
    }

    public static void CheckEndings()
    {
        if (demonicGrasp >= deathThreshold)
        {
            SceneManager.LoadScene("Scenes/Endings/Demonic Ending");
        }
        if (guildSuspicion >= deathThreshold)
        {
            SceneManager.LoadScene("Scenes/Endings/Suspicion Ending");
        }
    }

    public static void AnotherDaySurvived()
    {
        daysSurvived++;
    }

    public static void AnotherQuestCompleted(bool success)
    {
        if (success)
        {
            questsSucceeded++;
        }
        else
        {
            questsFailed++;
        }
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
