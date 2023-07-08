using UnityEngine;

public static class DialogueImporter
{
    private const string DialogueFolder = "Dialogue/";
    private static readonly char[] lineEndChars = new char[] { '\n', '\r' };

    public static string[] ImportDialogueFromName(string dialogName)
    {
        if(dialogName == "")
        {
            return new string[] { "GM: Awake.", "GM: Job.", "You: uuuuuuuuuuuuuuuuuuuuuuuuuh." };
        }
        TextAsset file = Resources.Load<TextAsset>(DialogueFolder + dialogName);
        return file.text.Split('\n');
    }

    public static string[] ImportExitLines()
    {
        TextAsset file = Resources.Load<TextAsset>(DialogueFolder + "CharacterExitLines");
        return file.text.Split('\n');
    }
}
