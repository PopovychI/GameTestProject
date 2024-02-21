using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Assertions;
using Zenject;

public class UpgradeController : MonoBehaviour
{
    [SerializeField] private List<UpgradeBoxView> upgradePrefabs;
    [SerializeField] private int costPerLevel = 15;

    [Inject] private PlayerModel playermodel;
    [Inject] private PlayerController playerContr;

    [Inject] private GameController gameContr;
    [Inject] private CurrencyController currencyContr;

    [Inject] private readonly BoatsData boatList;
    [Inject] private readonly WeaponsData weaponList;

    public int WeaponUpgradeCost => costPerLevel * playermodel.playerWeapons.level;
    public int BoatUpgradeCost => costPerLevel * playermodel.playerBoat.Level;

    public void UpgradeToNextShip()
    {
        gameContr.StartGame();
        Assert.IsTrue(playermodel.playerBoat.Level < boatList.data.Count);
        if (!currencyContr.TrySpendCoins(BoatUpgradeCost)) return;
        playerContr.UpgradePlayerBoat(boatList.data[playermodel.playerBoat.Level]);
    }
    public void UpgradeToNextWeapon()
    {
        gameContr.StartGame();
        Assert.IsTrue(playermodel.playerWeapons.level + 1 < weaponList.data.Count);
        if (!currencyContr.TrySpendCoins(WeaponUpgradeCost)) return;
        playerContr.UpgradePlayerWeapon(weaponList.data[playermodel.playerWeapons.level + 1]);
    }
    public void ConnectView(UpgradeView view)
    {
        if (currencyContr.CoinsCount < (BoatUpgradeCost & WeaponUpgradeCost))
        {
            gameContr.StartGame();
            return;
        }
        view.PopulateView(upgradePrefabs);        
        view.ShowView();
    }
    public void ConnectView(UpgradeBoatView view)
    {
        view.Price.text = (BoatUpgradeCost).ToString();
        view.UpgradeButton.onClick.AddListener(UpgradeToNextShip);
    }
    public void ConnectView(UpgradeWeaponView view)
    {
        view.Price.text = (WeaponUpgradeCost).ToString();
        view.UpgradeButton.onClick.AddListener(UpgradeToNextWeapon);
    }
}
