using R3;
using UnityEngine;
using Zenject;

public class LevelUIBinder : MonoBehaviour
{
    [SerializeField] private TextView _levelView;
    [SerializeField] private TextView _experienceView;
    [SerializeField] private TextView _experiencePerClickView;

    [Space]
    [SerializeField] private ButtonView _moneyPerClickButton;

    private LevelViewModel _levelViewModel;
    private CompositeDisposable _disposables = new();

    [Inject]
    private void Constructor(LevelViewModel levelViewModel)
    {
        _levelViewModel = levelViewModel;
    }

    private void Start()
    {
        _levelViewModel.Level
            .Subscribe(level => _levelView.CurrencyText.text = level)
            .AddTo(_disposables);

        _levelViewModel.Experience
            .Subscribe(experience => _experienceView.CurrencyText.text = experience)
            .AddTo(_disposables);

        _levelViewModel.ExperiencePerClick
            .Subscribe(experiencePerClick => _experiencePerClickView.CurrencyText.text = experiencePerClick)
            .AddTo(_disposables);

        _moneyPerClickButton.OnClick += AddExperienceButton;
    }

    private void AddExperienceButton()
    {
        _levelViewModel.AddExperience();
    }

    private void OnDestroy()
    {
        _disposables.Dispose();
    }
}
