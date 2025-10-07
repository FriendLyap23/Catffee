using System.Collections.Generic;

public class UpgradeFactory
{
    private readonly Dictionary<UpgradeConfig, UpgradesStorage> _cache = new();

    public UpgradesStorage Create(UpgradeConfig config) 
    {
        if (!_cache.ContainsKey(config))
        {
            _cache[config] = new UpgradesStorage(config);
        }

        return _cache[config];
    }
}
