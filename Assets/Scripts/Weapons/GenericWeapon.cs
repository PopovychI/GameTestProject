using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenericWeapon : Weapon
{
    private Timer timer = new Timer();

    private void Start()
    {
        timer.Start();
    }

    private void Update()
    {
        timer.Evaluate(Time.deltaTime);
        if  (timer.ElapsedTime > fireRate)
        {
            Shoot(-transform.right);
            timer.Restart();
        }
    }
    public override void Shoot(Vector3 direction)
    {
      var bull =  diCont.InstantiatePrefabForComponent<Bullet>(bullet);
        fireVfx.Play();
        bull.transform.position = firePoint.position;
        bull.Fire(direction, firePower, damage);
    }
}
