using R3;
using System;
using UnityEngine;
using Zenject;

public class UpgradeViewModel : IInitializable, IDisposable
{
    public UpgradesStorage _upgradesStorage { get; private set; }

    public readonly ReactiveProperty<string> Name = new();
    public readonly ReactiveProperty<string> Description = new();

    public readonly ReactiveProperty<string> Price = new();
    public readonly ReactiveProperty<Sprite> Icon = new();

    private UpgradeConfig _config;

    public UpgradeViewModel(UpgradeConfig config, UpgradesStorage upgradesStorage)
    {
        _config = config;
        _upgradesStorage = upgradesStorage;
    }

    public void Initialize()
    {
        Name.Value = _config.Name;
        Description.Value = _config.Description;
        Price.Value = _config.Price.ToString();
        Icon.Value = _config.Icon;

        _upgradesStorage.OnPriceChanged += PriceChanged;
    }

    private void NameChanged(UpgradeConfig config) 
    {
        Name.Value = config.Name;
    }

    private void DescriptionChanged(UpgradeConfig config)
    {
        Description.Value = config.Description;
    }

    private void PriceChanged(int newPrice)
    {
        Price.Value = newPrice.ToString();
    }

    private void IconChanged(UpgradeConfig config)
    {
        Icon.Value = config.Icon;
    }

    public void Dispose()
    {
        _upgradesStorage.OnPriceChanged -= PriceChanged;
    }
}
