public class UpgradesViewModelFactory
{
    private readonly UpgradeFactory _upgradeFactory;

    public UpgradesViewModelFactory(UpgradeFactory upgradeFactory)
    {
        _upgradeFactory = upgradeFactory;
    }

    public UpgradeViewModel Create(UpgradeConfig config)
    {
        var upgradesStorage = _upgradeFactory.Create(config);
        return new UpgradeViewModel(config, upgradesStorage);
    }
}
