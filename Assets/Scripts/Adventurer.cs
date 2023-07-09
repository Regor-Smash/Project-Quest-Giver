public class Adventurer
{
    public string adventurerName;
    public AdventurerClasses adventureClass;
    public uint level;
    public string[] keywords;

    public Adventurer(AdventurerSO so) //NamedAdventurer
    {
        this.adventurerName = so.adventurerName;
        this.adventureClass = so.adventureClass;
        this.level = so.level;
        this.keywords = so.keywords;
    }

    public Adventurer(string adventurerName, AdventurerClasses adventureClass, uint level, string[] secondaryKeywords)//RandomAdventurer
    {
        this.adventurerName = adventurerName;
        this.adventureClass = adventureClass;
        this.level = level;
        this.keywords = new string[secondaryKeywords.Length+1];
        keywords[0] = GetClassKeyword();
        for(int i = 1; i < secondaryKeywords.Length; i++)
        {
            keywords[i+1] = secondaryKeywords[i];
        }
    }

    private string GetClassKeyword()
    {
        switch (adventureClass)
        {
            case AdventurerClasses.Priest: return "religious";
            case AdventurerClasses.Ranger: return "wilderness";
            case AdventurerClasses.Sorcerer: return "study hall";
            case AdventurerClasses.Warrior: return "battlefield";
            default: return "heavy";
        }
    }

    public static string RandomName()
    {
        return "Mr. Nobody-" + UnityEngine.Random.Range(1, 101).ToString();
    }
}
