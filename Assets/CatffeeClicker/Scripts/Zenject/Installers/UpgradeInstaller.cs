using Zenject;

public class UpgradeInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<UpgradeFactory>().AsSingle();
        Container.Bind<PurchaseService>().AsSingle();
    }
}
