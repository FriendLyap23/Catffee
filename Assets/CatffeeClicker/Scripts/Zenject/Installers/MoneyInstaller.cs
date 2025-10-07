using UnityEngine;
using Zenject;

public sealed class MoneyInstaller : MonoInstaller
{
    [SerializeField] private int _initialMoney;
    [SerializeField] private int _initialMoneyPerClick;
    [SerializeField] private int _initialMoneyPerSecond;

    public override void InstallBindings()
    {
        var moneyStorage = new MoneyStorage(_initialMoney, _initialMoneyPerClick, _initialMoneyPerSecond);

        Container
            .Bind<MoneyStorage>()
            .FromInstance(moneyStorage)
            .AsSingle()
            .NonLazy();

        Container.BindInstance<IDataPersistence>(moneyStorage);
    }
}
