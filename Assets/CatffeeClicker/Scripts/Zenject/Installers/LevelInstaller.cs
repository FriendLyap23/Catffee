using UnityEngine;
using Zenject;

public class LevelInstaller : MonoInstaller
{
    [Header("Base  Settings")]
    [SerializeField] private int _initialLevel = 1;
    [SerializeField] private int _initialExp = 0;
    [SerializeField] private int _experiencePerClick = 1;

    [Space]

    [Header("Level Progression")]
    [SerializeField, Range(1, 100)] private int _maxLevel;
    [SerializeField] private float[] _experienceForLevel;

    public override void InstallBindings()
    {
        var levelStorage = new LevelStorage(_initialLevel, _initialExp, _experienceForLevel, _maxLevel, _experiencePerClick);

        Container
            .Bind<LevelStorage>()
            .FromInstance(levelStorage)
            .AsSingle()
            .NonLazy();

        Container.BindInstance<IDataPersistence>(levelStorage);
    }
}
