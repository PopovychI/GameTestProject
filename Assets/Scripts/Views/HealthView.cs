using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Zenject;
using DG.Tweening;
public class HealthView : MonoBehaviour
{
    [Inject] private PlayerController controller;
    private TextMeshProUGUI text;
    private void Awake()
    {
        text = GetComponentInChildren<TextMeshProUGUI>();
        controller.ConnectHealthView(this);
    }

    public void ChangeText(float value)
    {
        text.transform.DOComplete();
        text.text = value.ToString();
        text.transform.DOShakePosition(0.4f, 8);
    }
    private void OnDestroy()
    {
        text.transform.DOKill();
    }
}
