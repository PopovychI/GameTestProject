using UnityEngine;
using Zenject;

public class GenericLevelFinishInstaller : MonoInstaller
{
    [Inject] private GameController gameController;
    public override void InstallBindings()
    {
        GenericLevelFinished levelFinished = new(gameController);
        Container.Bind<ILevelFinishable>().FromInstance(levelFinished).AsSingle();
    }
}