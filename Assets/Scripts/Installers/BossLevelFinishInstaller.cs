using UnityEngine;
using Zenject;

public class BossLevelFinishInstaller : MonoInstaller
{
    [Inject] private LevelController levelController;
    public override void InstallBindings()
    {
        BossLevelFinish levelFinished = new(levelController);
        Container.Bind<ILevelFinishable>().FromInstance(levelFinished).AsSingle();
    }
}