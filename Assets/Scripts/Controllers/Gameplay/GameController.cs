using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class GameController : MonoBehaviour
{
    public System.Action OnLevelFinish, OnGameOver, OnGameStart;
    public System.Action<float> OnProgressUpdate;


    [SerializeField] private Transform startTransform;
    [SerializeField] private Transform finishTransform;
    [SerializeField] private Transform playerTransform;
    private float progress;

    public bool GameloopActive { get; set; }

    [Inject] private SceneController sceneController;


    private void Awake()
    {
        GameloopActive = false;
    }

    private void FixedUpdate()
    {
        GetProgress();
        OnProgressUpdate?.Invoke(progress);
    }
    public void StartGame()
    {
        GameloopActive = true;
        OnGameStart?.Invoke();
    }
    private void GetProgress()
    {
        var distanceFromStart = Vector3.Distance(startTransform.position, playerTransform.position);
        var fullDistance = Vector3.Distance(startTransform.position, finishTransform.position);
        progress = distanceFromStart / fullDistance;
    }

    public void ConnectView(GameOverView view)
    {
        OnGameOver += view.ShowView;
        view.RestartButton.onClick.AddListener(sceneController.RestartScene);
    }
    public void ConnectView(LevelCompleteView view)
    {
        OnLevelFinish += view.ShowView;
        view.NextButton.onClick.AddListener(sceneController.LoadNextScene);
    }
    public void ConnectView(ProgressView view)
    {
        OnProgressUpdate += view.UpdateProgress;
    }
    public void SetLevelFinished()
    {
        GameloopActive = false;
        OnLevelFinish?.Invoke();
    }
    public void SetGameOver()
    {
        GameloopActive = false;
        OnGameOver?.Invoke();
    }
}
