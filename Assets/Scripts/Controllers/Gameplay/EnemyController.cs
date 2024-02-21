using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class EnemyController : MonoBehaviour
{
    [Inject] private PlayerController playerController;
    [Inject] private CurrencyController currencyController;
    [SerializeField] private List<Enemy> enemyPrefabs;
    [Space(20)]
    [SerializeField] private List<Enemy> runtimeEnemyList = new();

    public List<Enemy> Enemies => runtimeEnemyList;


    public Transform MainTarget => playerController.PlayerTransform;

    [Inject] private DiContainer diCont;
    public void CreateEnemy(Transform stayPoint)
    {
        if (enemyPrefabs.Count == 0) return;
        var random = Random.Range(0, enemyPrefabs.Count);
        var enemy = diCont.InstantiatePrefabForComponent<Enemy>(enemyPrefabs[random]);
        enemy.SetStayPoint(stayPoint);
    }
    public EnemyBoss CreateEnemyBoss(Transform stayPoint, EnemyBoss enemy)
    {
        var enemyBoss = diCont.InstantiatePrefabForComponent<EnemyBoss>(enemy);
        enemyBoss.SetStayPoint(stayPoint);
        return enemyBoss;
    }

    public void Connect(Enemy enemy)
    {
        runtimeEnemyList.Add(enemy);
    }
    public void Disconnect(Enemy enemy)
    {
        currencyController.AddCoins(enemy.EnemyValue);
        runtimeEnemyList.Remove(enemy);
    }
}
