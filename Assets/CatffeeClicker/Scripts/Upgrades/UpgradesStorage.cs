using System;

public class UpgradesStorage : IDataPersistence
{
    public UpgradeConfig UpgradeConfig { get; set; }

    private bool _isFirstBuy;

    public event Action<int> OnPriceChanged;

    public UpgradesStorage(UpgradeConfig upgradeConfig)
    {
        UpgradeConfig = upgradeConfig;
        _isFirstBuy = true;
    }

    public void ApplyUpgrade(MoneyStorage moneyStorage)
    {
        switch (UpgradeConfig.Type)
        {
            case UpgradeType.MoneyPerClick:
                moneyStorage.SetMoneyPerClick(UpgradeConfig.Value);
                break;
            case UpgradeType.MoneyPerSecond:
                moneyStorage.SetMoneyPerSecond(UpgradeConfig.Value);
                break;
            default:
                break;
        }
    }

    public void RecalculationPrice() 
    {
        int newPrice = UpgradeConfig.Price + 5;

        UpgradeConfig.Price = newPrice;
        OnPriceChanged?.Invoke(newPrice);
    }

    public void LoadData(GameData data)
    {
        UpgradeConfig = data.UpgradeConfig;
    }

    public void SaveData(ref GameData data)
    {
        data.UpgradeConfig = UpgradeConfig;
    }
}
