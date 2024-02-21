using UnityEngine;
using Zenject;

public class LevelSceneControllersInstaller : MonoInstaller
{
    [SerializeField] private ObstaclesController obstaclesController;
    [SerializeField] private EnemyController enemyController;
    [SerializeField] private LevelController levelController;
    [SerializeField] private PlayerController playerController;
    [SerializeField] private CurrencyController currencyController;
    [SerializeField] private GameController gameController;
    [SerializeField] private UpgradeController upgradeController;
    public override void InstallBindings() // have to optimize/change this later
    {
        Container.Bind<GameController>().FromInstance(gameController).AsSingle();
        Container.Bind<ObstaclesController>().FromInstance(obstaclesController).AsSingle();    
        Container.Bind<EnemyController>().FromInstance(enemyController).AsSingle();        
        Container.Bind<PlayerController>().FromInstance(playerController).AsSingle();
        Container.Bind<CurrencyController>().FromInstance(currencyController).AsSingle();        
        Container.Bind<LevelController>().FromInstance(levelController).AsSingle();
        Container.Bind<UpgradeController>().FromInstance(upgradeController).AsSingle();               
        
    }
}