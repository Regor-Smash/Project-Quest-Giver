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
            ClearPrefs();
            SceneManager.LoadScene("Scenes/Endings/Demonic Ending");
        }
        if (guildSuspicion >= deathThreshold)
        {
            ClearPrefs();
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

    private static void ClearPrefs()
    {
        PlayerPrefs.SetInt("Days Survived", 0);
        PlayerPrefs.SetFloat("Demonic Grasp", 0);
        PlayerPrefs.SetFloat("Guild Suspicion", 0);

        PlayerPrefs.Save();
    }

    public static void SaveToPrefs()
    {
        PlayerPrefs.SetInt("Days Survived", daysSurvived);
        PlayerPrefs.SetFloat("Demonic Grasp", demonicGrasp);
        PlayerPrefs.SetFloat("Guild Suspicion", guildSuspicion);

        PlayerPrefs.Save();
    }

    public static void LoadFromPrefs()
    {
        daysSurvived = PlayerPrefs.GetInt("Days Survived", 0);
        demonicGrasp = PlayerPrefs.GetFloat("Demonic Grasp", 0);
        guildSuspicion = PlayerPrefs.GetFloat("Guild Suspicion", 0);
    }
}
