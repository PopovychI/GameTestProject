using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public abstract class Obstacle : MonoBehaviour
{
    [SerializeField] protected LayerMask layerToHit;

    [Inject] protected ObstaclesController controller;
    protected abstract void GetHit();

    protected virtual void OnTriggerEnter(Collider other)
    {
        if (((layerToHit & (1 << other.gameObject.layer)) != 0))
        {
            GetHit();
            Destroy(gameObject);
        }
    }
}
