using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "LevelsList", menuName = "Game/LevelsList")]
public class LevelsData : ScriptableObject
{
    public List<LevelInfo> data;

}
