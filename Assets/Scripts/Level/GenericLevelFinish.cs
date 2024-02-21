using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class GenericLevelFinished : ILevelFinishable
{

    private GameController gameController;
    public GenericLevelFinished(GameController gameCont)
    {
        gameController = gameCont;
    }
    public void OnFinishReached()
    {
        gameController.SetLevelFinished();
    }
}
