using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "BoatsList", menuName = "Game/BoatsList")]
public class BoatsData : ScriptableObject
{
    public List<Boat> data;
}
