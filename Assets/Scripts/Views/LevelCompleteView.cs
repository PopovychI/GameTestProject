using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class LevelCompleteView : MonoBehaviour
{
    [SerializeField] private Button nextButton;
    public Button NextButton => nextButton;

    [Inject] private GameController controller;

    private void Awake()
    {
        controller.ConnectView(this);
    }

    public void ShowView()
    {
        transform.GetChild(0).gameObject.SetActive(true);
    }
}
