using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class QuestDisplay : MonoBehaviour
{
    public TextMeshProUGUI questTitle;
    public TextMeshProUGUI questDescription;
    public Image demonicInfluenceGauge;

    private Quest currQ;

    public void DisplayQuest(Quest q, Party p)
    {
        currQ = q;
        questTitle.text = q.questName;
        questDescription.text = "This is a quest for Level " + q.level.ToString() + " adventurers. It would be " + q.SuccessTier(p).ToString() + " that your party completes it.";
        demonicInfluenceGauge.fillAmount = q.demonicInfluence / 100;
    }

    public void ChooseQuest()
    {
        QuestGiving.instance.PickQuest(currQ);
    }
}
