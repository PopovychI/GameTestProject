using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public abstract class Boat : MonoBehaviour
{
    [SerializeField] protected int level;
    [SerializeField] protected float health;


    [SerializeField] protected List<Transform> weaponPlaceholder;

    [Tooltip("Visuals")]
    [SerializeField] protected ParticleSystem appearVFX;
    [SerializeField] protected ParticleSystem getHitVFX;

    public int Level => level;
    public float Health => health;
    public List<Transform> WeaponsHolder => weaponPlaceholder;

    protected virtual void OnEnable()
    {
        appearVFX.Play();
    }

}
