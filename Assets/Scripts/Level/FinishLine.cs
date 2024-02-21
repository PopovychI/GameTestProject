using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class FinishLine : MonoBehaviour
{
    [Inject] private ILevelFinishable finishable;

    private void OnTriggerEnter(Collider other)
    {
        finishable.OnFinishReached();
        enabled = false;
    }
}
