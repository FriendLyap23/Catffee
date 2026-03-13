using IncrementalGameTemplateMVVMBased.DataPersistence.Data;
using IncrementalGameTemplateMVVMBased.Level;
using IncrementalGameTemplateMVVMBased.Scripts.Currency;
using IncrementalGameTemplateMVVMBased.Upgrades;
using IncrementalGameTemplateMVVMBased.Upgrades.Factories;
using UnityEngine;
using Zenject;

namespace IncrementalGameTemplateMVVMBased.Zenject.Installers
{
    public class GameCoreInstaller : MonoInstaller
    {
        [SerializeField] private SaveConfig _saveConfig;

        public override void InstallBindings()
        {
            BindMoneySystem();
            BindLevelSystem();
            BindUpgradeSystem();

            Container.BindInstance(_saveConfig).AsSingle();

            Debug.Log("All core dependencies registered!");
        }

        private void BindMoneySystem()
        {
            Container.BindInterfacesAndSelfTo<MoneyStorage>().AsSingle().NonLazy();
        }

        private void BindLevelSystem()
        {
            Container.BindInterfacesAndSelfTo<LevelStorage>().AsSingle().NonLazy();
        }

        private void BindUpgradeSystem()
        {
            Container.BindInterfacesAndSelfTo<UpgradeRegistry>().AsSingle();
            Container.BindInterfacesAndSelfTo<UpgradeFactory>().AsSingle();

            Container.Bind<PurchaseService>().AsSingle();
        }
    }
}