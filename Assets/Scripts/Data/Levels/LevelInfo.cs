using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class LevelInfo
{
    public EnemyBoss boss; // leave null if not boss level
    public int enemies;
    public int obstacles;
}
