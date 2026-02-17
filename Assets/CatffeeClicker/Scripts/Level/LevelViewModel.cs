using R3;
using System;
using Zenject;

public class LevelViewModel : IInitializable, IDisposable
{
    private LevelStorage _levelStorage;

    private CompositeDisposable _disposables = new();

    public readonly ReactiveProperty<string> Level = new();
    public readonly ReactiveProperty<string> Experience = new();
    public readonly ReactiveProperty<string> ExperiencePerClick = new();

    public LevelViewModel(LevelStorage levelStorage)
    {
        _levelStorage = levelStorage;
    }

    public void Initialize()
    {
        _levelStorage.CurrentLevel.Subscribe(LevelChanged).AddTo(_disposables);
        _levelStorage.CurrentExperienceLevel.Subscribe(ExperienceChanged).AddTo(_disposables);
        _levelStorage.ExperiencePerClick.Subscribe(ExperiencePerClickChanged).AddTo(_disposables);
    }

    private void LevelChanged(int level)
    {
        Level.Value = level.ToString();
    }

    public void AddExperience()
    {
        _levelStorage.AddExperiencePerClick();
    }

    private void ExperienceChanged(int experience)
    {
        Experience.Value = experience.ToString();
    }

    private void ExperiencePerClickChanged(int experience)
    {
        ExperiencePerClick.Value = experience.ToString();
    }

    public void Dispose()
    {
        _disposables.Dispose();

        Level.Dispose();
        Experience.Dispose();
        ExperiencePerClick.Dispose();
    }
}
