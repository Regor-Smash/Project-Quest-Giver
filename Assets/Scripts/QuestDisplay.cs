using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class QuestDisplay : MonoBehaviour
{
    public TextMeshProUGUI questTitle;
    public TextMeshProUGUI questDescription;
    public TextMeshProUGUI positiveTraits;
    public TextMeshProUGUI negativeTraits;
    public TextMeshProUGUI level;
    public TextMeshProUGUI location;
    public TextMeshProUGUI successTier;
    public TextMeshProUGUI demon;
    public TextMeshProUGUI reward;

    private Quest currQ;
    private Party currP;

    public void DisplayQuest(Quest q, Party p)
    {
        currQ = q;
        currP = p;

        questTitle.text = q.questName;
        questDescription.text = "Go do the thing!";
        
        level.text = q.level.ToString();
        location.text = "Swamp";
        successTier.text = q.GetSuccessTier(p).ToString();
        demon.text = q.demonicInfluence.ToString("0.#%");
        reward.text = (20 * q.level).ToString() + " Gold";
    }

    public void ChooseQuest()
    {
        QuestGiving.Instance.PickQuest(currQ, currP);
    }
}
