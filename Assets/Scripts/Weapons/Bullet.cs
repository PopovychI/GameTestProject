using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;
using UnityEngine.UI;

public class Bullet : MonoBehaviour
{
    [SerializeField] private Rigidbody rbody;
    [SerializeField] private ParticleSystem hitVFX;
    [SerializeField] private LayerMask layerMask;
    private float damage;
    public void Fire(Vector3 direction, float firePower, float damageValue)
    {
        rbody.AddForce(direction * firePower*100);
        damage = damageValue;
        Invoke(nameof(Destroy), 5f);
    }

    protected virtual void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out IDamageable damageable) && ((layerMask & (1 << other.gameObject.layer)) != 0))
        {
            damageable.GetDamaged(damage);
            hitVFX.transform.parent = null;
            hitVFX.Play();
            gameObject.SetActive(false);
        }
    }
    private void Destroy()
    {
        Destroy(gameObject);
    }
}
