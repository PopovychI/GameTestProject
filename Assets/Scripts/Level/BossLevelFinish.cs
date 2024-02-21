using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class BossLevelFinish : ILevelFinishable
{

    private LevelController levelController;
    public BossLevelFinish(LevelController levelCont)
    {
        levelController = levelCont;
    }

    public void OnFinishReached()
    {
        levelController.StartBossBattle();
    }
}
