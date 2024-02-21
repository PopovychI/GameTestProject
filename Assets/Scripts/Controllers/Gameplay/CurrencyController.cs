using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Zenject;

public class CurrencyController : MonoBehaviour
{
    public System.Action<int> OnCoinsCountChanged;

    [Inject] private CurrenciesModel model;

    public int CoinsCount => model.coinsCount;


    public void AddCoins(int value)
    {
        model.coinsCount += value;
        OnCoinsCountChanged?.Invoke(model.coinsCount);
    }

    public bool TrySpendCoins(int value)
    {
        if (model.coinsCount < value) return false;
        model.coinsCount -= value;
        OnCoinsCountChanged?.Invoke(model.coinsCount);
        return true;
    }

    public void ConnectView(CoinView view)
    {
        OnCoinsCountChanged += view.ChangeText;
        OnCoinsCountChanged?.Invoke(model.coinsCount);
    }
    private void OnDestroy()
    {
        OnCoinsCountChanged = null;
    }
}
