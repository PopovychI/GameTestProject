using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class UpgradeView : MonoBehaviour
{
    [Inject] private UpgradeController controller;
    [Inject] private DiContainer diCont;


    private void Start()
    {
        controller.ConnectView(this);
    }

    public void ShowView()
    {
        transform.GetChild(0).gameObject.SetActive(true);
    }
    public void HideView()
    {
        transform.GetChild(0).gameObject.SetActive(false);
    }
    public void PopulateView(List<UpgradeBoxView> views)
    {
        for (int i = 0; i < views.Count; i++)
        {
          var view =  diCont.InstantiatePrefabForComponent<UpgradeBoxView>(views[i], transform.GetChild(0));
          view.UpgradeButton.onClick.AddListener(HideView);
        }
    }
}
