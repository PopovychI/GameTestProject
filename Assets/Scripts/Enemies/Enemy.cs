using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Zenject;

public abstract class Enemy : MonoBehaviour
{
    public System.Action OnDestroyed;

    [SerializeField] protected  int  enemyValue;
    [SerializeField] protected Transform stayPoint;
    [SerializeField] protected ParticleSystem destroyVFX;
    [SerializeField] protected List<EnemyWeapon> weapons;
    [SerializeField] protected float health;
    [SerializeField] protected LayerMask playerLayer;
    [SerializeField] protected float stayPointDistance;
    [SerializeField] protected float aggroDistance;

    protected Transform playerTransform;
    protected Rigidbody rbody;
    protected Timer shootTimer = new();
    protected bool playerInSight;

    public int EnemyValue => enemyValue;

    [Inject] private EnemyController controller;

    public void SetStayPoint(Transform point)
    {
        stayPoint = point;
        transform.position = stayPoint.position;
    }

    protected virtual void Awake()
    {
        rbody = GetComponent<Rigidbody>();
    }

    private void OnEnable()
    {
        playerTransform = controller.MainTarget;
        controller.Connect(this);
    }
    protected virtual void Update()
    {
        if (!playerInSight && Vector3.Distance(playerTransform.position, transform.position) < aggroDistance)
        {
            playerInSight = true;
            for (int i = 0; i < weapons.Count; i++)
            {
                weapons[i].StartTimer();
            }

        }

        if (playerInSight) CheckForPlayer();
    }
    protected virtual void FixedUpdate()
    {
        transform.LookAt(playerTransform);
        // for fixed position on map, so it doesnt drift
        if (Vector3.Distance(stayPoint.position, transform.position) > stayPointDistance) rbody.AddForce((stayPoint.position - transform.position).normalized * 10f);
    }

    protected virtual void CheckForPlayer()
    {
        if (playerTransform.position.x < transform.position.x) // player goes past enemy
        {
            DisableBehaviour();
        }
    }

    public void GetDamaged(float value)
    {
        health -= value;
        if (health < 0)
        {
            OnDestroyed?.Invoke();
            Destroy(gameObject);
        }
    }
    protected virtual void DisableBehaviour()
    {
        for (int i = 0; i < weapons.Count; i++)
        {
            weapons[i].StopTimer();
        }
        enemyValue = 0;
        controller.Disconnect(this);
        enabled = false;
    }

    protected virtual void OnDestroy()
    {
        destroyVFX.transform.parent = null;
        destroyVFX.Play();
        controller.Disconnect(this);
    }

    protected virtual void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out IDamageable damageable) && ((playerLayer & (1 << other.gameObject.layer)) != 0))
        {
            damageable.GetDamaged(health);
            Destroy(gameObject);
        }
    }
}
