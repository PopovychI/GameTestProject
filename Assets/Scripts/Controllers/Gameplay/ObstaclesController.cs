using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class ObstaclesController : MonoBehaviour
{
    [SerializeField] private List<Obstacle> obstaclePrefabs;
    [Space(20)]
    [SerializeField] private List<Obstacle> runtimeObstacleList = new();

    public List<Obstacle> Obstacles => runtimeObstacleList;

    [Inject] private DiContainer diCont;
    [Inject] private CurrencyController currencyController;


    public void CreateObstacle(Vector3 position)
    {
        if (obstaclePrefabs.Count == 0) return;
        var random = Random.Range(0, obstaclePrefabs.Count);
        var obstacle = diCont.InstantiatePrefabForComponent<Obstacle>(obstaclePrefabs[random]);
        obstacle.transform.position = position;
    }

    public void Connect(Obstacle obstacle)
    {
        runtimeObstacleList.Add(obstacle);
    }
    public void Disconnect(Obstacle obstacle)
    {
        runtimeObstacleList.Remove(obstacle);
    }
    public void AddPoints(int value)
    {
        currencyController.AddCoins(value);
    }
}
