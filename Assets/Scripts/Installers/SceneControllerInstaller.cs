using UnityEngine;
using Zenject;

public class SceneControllerInstaller : MonoInstaller
{
    [SerializeField] private SceneController sceneController;
    public override void InstallBindings()
    {
        Container.Bind<SceneController>().FromInstance(sceneController).AsSingle();
    }
}