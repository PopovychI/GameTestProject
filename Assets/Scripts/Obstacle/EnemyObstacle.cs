using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyObstacle : Obstacle
{
    [SerializeField] private float damage;
    [SerializeField] private ParticleSystem getHitVfx;
    protected override void GetHit()
    {
        getHitVfx.transform.parent = null;
        getHitVfx.Play();
        gameObject.SetActive(false);
    }

    protected override void OnTriggerEnter(Collider other)
    {
        if (((layerToHit & (1 << other.gameObject.layer)) != 0))
        {
            if (other.TryGetComponent(out IDamageable damageable)) damageable.GetDamaged(damage);
            GetHit();
        }
    }
}
