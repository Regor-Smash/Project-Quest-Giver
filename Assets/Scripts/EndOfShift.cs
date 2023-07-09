using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EndOfShift : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI daysSurvivedText;
    [SerializeField]
    private TextMeshProUGUI questsFailedText;
    [SerializeField]
    private TextMeshProUGUI questsCompletedText;

    [SerializeField]
    private TextMeshProUGUI demonGraspText;
    [SerializeField]
    private TextMeshProUGUI suspicionText;


    private void Start()
    {
        UpdateDisplays();
        StartCoroutine(nameof(DisplayResults));
    }

    private void UpdateDisplays()
    {
        daysSurvivedText.text = PlayerStats.daysSurvived.ToString();
        questsFailedText.text = PlayerStats.questsFailed.ToString();
        questsCompletedText.text = PlayerStats.questsSucceeded.ToString();

        demonGraspText.text = PlayerStats.DemonPercent().ToString("0.##%");
        suspicionText.text = PlayerStats.SuspicionPercent().ToString("0.##%");
    }

    IEnumerator DisplayResults()
    {
        yield return new WaitForSeconds(3f);
        PlayerStats.AnotherDaySurvived();
        UpdateDisplays();
        yield return new WaitForSeconds(1f);

        while (QuestGiving.currentQuests.Count > 0)
        {
            AcceptedQuest q = QuestGiving.currentQuests[0];
            QuestGiving.currentQuests.RemoveAt(0);

            q.Finish();

            UpdateDisplays();
            yield return new WaitForSeconds(1f);
        }

        PlayerStats.SaveToPrefs();
        PlayerStats.CheckEndings();
    }
}
