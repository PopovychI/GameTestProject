using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : Obstacle
{
    [SerializeField] private int value;
    [SerializeField] private ParticleSystem getHitVfx;
    protected override void GetHit()
    {
        controller.AddPoints(value);
        getHitVfx.transform.parent = null;
        getHitVfx.Play();
        gameObject.SetActive(false);
    }

    protected override void OnTriggerEnter(Collider other)
    {
        if (((layerToHit & (1 << other.gameObject.layer)) != 0))
        {
           GetHit();           
        }
    }
}
