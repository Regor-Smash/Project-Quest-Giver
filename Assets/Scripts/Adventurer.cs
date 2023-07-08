public class Adventurer
{
    public string adventurerName;
    public string adventureClass;
    public uint level;
    public string[] keywords;

    public Adventurer(AdventurerSO so)
    {
        this.adventurerName = so.adventurerName;
        this.adventureClass = so.adventureClass;
        this.level = so.level;
        this.keywords = so.keywords;
    }
}
