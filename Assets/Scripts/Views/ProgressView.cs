using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class ProgressView : MonoBehaviour
{
    [Inject] private GameController controller;
    [SerializeField] private Image progressBar; 

    private void Start()
    {
        controller.ConnectView(this);
    }

    public void UpdateProgress(float percent)
    {
        progressBar.fillAmount = percent;
    }
}
