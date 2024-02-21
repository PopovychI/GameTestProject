
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class LevelController : MonoBehaviour
{


    [SerializeField] private List<Transform> stayPoints;
    [SerializeField] private Transform bossStayPoint;
    [SerializeField] private Transform[] bossMovePoints;
    [SerializeField] private LevelsData data;
    private LevelInfo currentLevelInfo;



    [Inject] private EnemyController enemyController;
    [Inject] private PlayerController playerController;
    [Inject] private GameController gameController;
    [Inject] private ObstaclesController obstaclesController;

    private void Start()
    {
        InitializeLevel(data.data[0]);
    }

    public void InitializeLevel(LevelInfo levelInfo)
    {
        currentLevelInfo = levelInfo;
        for (int i = 0; i < stayPoints.Count; i++)
        {

            if (enemyController.Enemies.Count == currentLevelInfo.enemies) break;
            PopulateWithEnemies();
        }
        for (int i = 0; i < stayPoints.Count; i++)
        {
            if (obstaclesController.Obstacles.Count > currentLevelInfo.obstacles) break;
            PopulateWithObstacles();
        }
    }
    private void PopulateWithEnemies()
    {
        var random = Random.Range(0, stayPoints.Count);
        if (!stayPoints[random].gameObject.activeSelf) return;
        enemyController.CreateEnemy(stayPoints[random]);
        stayPoints[random].gameObject.SetActive(false);
    }
    private void PopulateWithObstacles()
    {
        var random = Random.Range(0, stayPoints.Count);
        if (!stayPoints[random].gameObject.activeSelf) return;
        obstaclesController.CreateObstacle(stayPoints[random].position);
        stayPoints[random].gameObject.SetActive(false);
    }

    public void StartBossBattle()
    {
        var boss = enemyController.CreateEnemyBoss(bossStayPoint, currentLevelInfo.boss);
        boss.SetMovePoints(bossMovePoints);
        boss.OnDestroyed += gameController.SetLevelFinished;
        playerController.SetBossBattleMode();
    }
}
