[System.Serializable]
public class GameData
{
    public int Money;
    public int MoneyPerClick;
    public int MoneyPerSecond;

    public int CurrentLevel;
    public float CurrentExperienceLevel;
    public int ExperiencePerClick;

    public UpgradeConfig UpgradeConfig;

    public GameData() 
    {
        Money = 0;
        MoneyPerClick = 1;

        CurrentLevel = 1;
        CurrentExperienceLevel = 0;
        ExperiencePerClick = 1;

        UpgradeConfig = new UpgradeConfig();
    }
}
