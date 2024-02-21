using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeWeaponView : UpgradeBoxView
{


    private void Awake()
    {
        controller.ConnectView(this);
    }
}
