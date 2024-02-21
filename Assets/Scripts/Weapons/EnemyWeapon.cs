using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
using Zenject.SpaceFighter;

public class EnemyWeapon : Weapon
{
    private Timer timer = new Timer();
    [SerializeField] private bool fireAtPlayer;

    [Inject] private EnemyController enemyController;

    public void StartTimer()
    {
        timer.Start();
        timer.Evaluate(fireRate);
    }
    public void StopTimer()
    {
        timer.Stop();
    }

    private void Update()
    {
        timer.Evaluate(Time.deltaTime);
        if (timer.ElapsedTime > fireRate)
        {
            if (!fireAtPlayer) Shoot(-transform.right);
            else Shoot((enemyController.MainTarget.position- firePoint.position).normalized);
            timer.Restart();
        }
    }
    public override void Shoot(Vector3 direction)
    {
        var bull = diCont.InstantiatePrefabForComponent<Bullet>(bullet);
        fireVfx.Play();
        bull.transform.position = firePoint.position;
        bull.Fire(direction, firePower, damage);
    }
}
