using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public abstract class Weapon : MonoBehaviour
{
    [SerializeField] protected int damage;
    [SerializeField] protected float fireRate;
    [SerializeField] protected int firePower;
    [SerializeField] protected ParticleSystem fireVfx;
    [SerializeField] protected Bullet bullet;
    [SerializeField] protected Transform firePoint;

    [Inject] protected DiContainer diCont;
    public abstract void Shoot(Vector3 direction);
}
