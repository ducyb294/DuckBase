namespace TheOneStudio.DuckBase.Scripts.Elements
{
    using Zenject;

    public class ElementInstaller : Installer<ElementInstaller>
    {
        public override void InstallBindings() { this.Container.Bind<ElementManager>().AsSingle().NonLazy(); }
    }
}