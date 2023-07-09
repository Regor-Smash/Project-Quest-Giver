using UnityEngine;

[CreateAssetMenu (fileName = "Blank Quest", menuName = "Scriptable Objects/New Quest", order = 0)]
public class QuestSO : ScriptableObject
{
    public string questName;
    public uint level;
    public float demonicInfluence;//percentage
    //public uint travelTime;
    public bool urgent;
    public string[] positiveKeywords;
    public string[] negativeKeywords;

    private void OnValidate()
    {
        if(questName == "")
        {
            Debug.LogError("Quest needs a name!", this);
        }
        level = (uint)Mathf.Clamp(level, 1, 25);
        demonicInfluence = Mathf.Clamp(demonicInfluence, -100f, 100f);
        //travelTime = (uint)Mathf.Clamp((int)travelTime, 1, 10);
    }
}
