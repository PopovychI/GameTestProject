using UnityEngine;
using Zenject;

public class BoatsDataInstaller : MonoInstaller<BoatsDataInstaller>
{
    [SerializeField] private BoatsData data;
    public override void InstallBindings()
    {
        Container.Bind<BoatsData>().FromInstance(data).AsSingle();
    }
}