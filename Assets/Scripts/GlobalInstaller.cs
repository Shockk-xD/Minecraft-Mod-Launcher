using Zenject;

public class GlobalInstaller : MonoInstaller
{
    public override void InstallBindings() {
        InstallSceneLoader();
        InstallModData();
    }

    private void InstallModData() {
        ModDataProjectContainer modDataProjectContainer = new();
        Container.Bind<ModDataProjectContainer>()
                    .FromInstance(modDataProjectContainer)
                    .AsSingle();
    }

    private void InstallSceneLoader() {
        Container.Bind<SceneLoader>()
                    .AsSingle();
    }
}
