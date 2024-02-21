using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class GameOverView : MonoBehaviour
{
    [SerializeField] private Button restartButton;


    [Inject] private GameController controller;

    public Button RestartButton => restartButton;
  

    private void Awake()
    {
        controller.ConnectView(this);
    }

    public void ShowView()
    {
        transform.GetChild(0).gameObject.SetActive(true);
    }
}
