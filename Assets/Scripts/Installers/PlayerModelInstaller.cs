using UnityEngine;
using Zenject;

public class PlayerModelInstaller : MonoInstaller
{
    [SerializeField] private PlayerModel playerModel;
    public override void InstallBindings()
    {
        Container.Bind<PlayerModel>().FromInstance(playerModel).AsSingle();
    }
}