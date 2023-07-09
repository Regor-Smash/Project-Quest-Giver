using UnityEngine;

[CreateAssetMenu(fileName = "Blank Named Adventurer", menuName = "Scriptable Objects/New Named Adventurer", order = 1)]
public class AdventurerSO : ScriptableObject
{
    public string adventurerName;
    public AdventurerClasses adventureClass;
    public uint level;
    public string[] keywords;

    private void OnValidate()
    {
        if (adventurerName == "")
        {
            Debug.LogError("Adventurer needs a name!", this);
        }
        //adventureClass
        level = (uint)Mathf.Clamp(level, 1, 20);
    }
}
