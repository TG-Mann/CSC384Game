using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyOneIdle : IEnemyOneState
{
    public void Enter(EnemyOne enemyOne)
    {
        enemyOne.setEnemyOneState("Idle");
    }

    public void Exit(EnemyOne enemyOne)
    {
        
    }

    public void frameUpdate()
    {
       
    }

    public void physicsUpdate()
    {
        
    }

    public IEnemyOneState Tick(EnemyOne enemyOne, Animator animator)
    {
        if (enemyOne.distanceToPlayer() < 20 && enemyOne.getTimeSinceAttack() > 50){
            return new EnemyOneWalk();
        }
        return null;
    }
}
