using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class UpgradeBoxView : MonoBehaviour
{
    [SerializeField] protected Button button;
    [SerializeField] protected TextMeshProUGUI price;


    [Inject] protected UpgradeController controller;

    public Button UpgradeButton => button;
    public TextMeshProUGUI Price => price;

}
