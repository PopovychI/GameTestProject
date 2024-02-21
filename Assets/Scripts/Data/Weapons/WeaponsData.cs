using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "WeaponsList", menuName = "Game/WeaponsList")]
public class WeaponsData : ScriptableObject
{
    public List<WeaponsList> data;
}

[Serializable]
public class WeaponsList // To support more than 1 weapon on ship
{
    public int level;
    public List<Weapon> list;
}
