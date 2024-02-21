using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeBoatView : UpgradeBoxView
{


    private void Awake()
    {
        controller.ConnectView(this);
    }
}
