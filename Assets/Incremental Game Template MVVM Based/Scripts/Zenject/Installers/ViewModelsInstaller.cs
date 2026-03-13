using IncrementalGameTemplateMVVMBased.Level;
using IncrementalGameTemplateMVVMBased.Scripts.Currency;
using IncrementalGameTemplateMVVMBased.Upgrades.Factories;
using Zenject;

namespace IncrementalGameTemplateMVVMBased.Zenject.Installers
{
    public sealed class ViewModelsInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container
                .BindInterfacesAndSelfTo<MoneyViewModel>()
                .AsSingle()
                .NonLazy();

            Container
                .BindInterfacesAndSelfTo<LevelViewModel>()
                .AsSingle()
                .NonLazy();

            Container
                .Bind<UpgradesViewModelFactory>()
                .AsSingle()
                .NonLazy();
        }
    }
}