using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour, IDamageable
{
    public System.Action OnDestroyed;
    public System.Action<float> OnHealthChange;

    [SerializeField] protected float health;
    protected float maxHealth;

    [SerializeField] private Boat boat;
    [SerializeField] private WeaponsList weapons = new();
    [SerializeField] private Rigidbody rbody;
    [SerializeField] private PlayerMovement movement;

    public int BoatLevel => CurrentBoat.Level;
    public int WeaponLevel => weapons.level;

    public float Health
    {
        get => health;

        set
        {
            health = value;
            OnHealthChange?.Invoke(health);
        }
    }
    public Boat CurrentBoat { get => boat; set => boat = value; }
    public WeaponsList CurrentWeapons { get => weapons; set => weapons = value; }
    public Rigidbody RBody { get => rbody; }
    public PlayerMovement Movement { get => movement; }
    public virtual void GetDamaged(float value)
    {
        health -= value;
        OnHealthChange?.Invoke(health);
        if (health <= 0)
        {
            OnDestroyed?.Invoke();
            gameObject.SetActive(false);
        }
    }

}
