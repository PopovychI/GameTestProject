using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Zenject;
using DG.Tweening;

public class CoinView : MonoBehaviour
{
    [Inject] private CurrencyController controller;
    private TextMeshProUGUI text;
    private void Awake()
    {
        text = GetComponentInChildren<TextMeshProUGUI>();
        controller.ConnectView(this);
    }

    public void ChangeText(int value)
    {
        if (text) text.transform.DOComplete();
        text.text = value.ToString();
        if (text) text.transform.DOShakePosition(0.2f, 8);
    }
}
