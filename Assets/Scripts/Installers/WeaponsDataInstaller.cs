using UnityEngine;
using Zenject;

public class WeaponsDataInstaller : MonoInstaller
{
    [SerializeField] private WeaponsData data;
    public override void InstallBindings()
    {
        Container.Bind<WeaponsData>().FromInstance(data).AsSingle();
    }
}