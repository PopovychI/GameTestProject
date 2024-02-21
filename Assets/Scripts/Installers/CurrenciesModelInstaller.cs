using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using Zenject;

public class CurrenciesModelInstaller : MonoInstaller
{
    [SerializeField] private CurrenciesModel currenciesModel;
    public override void InstallBindings()
    {
        Container.Bind<CurrenciesModel>().FromInstance(currenciesModel).AsSingle();
    }
}
