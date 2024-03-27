using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyOneDead : IEnemyOneState
{

    private Animator animator; 

    public void Enter(EnemyOne enemyOne)
    {
        animator = enemyOne.GetComponent<Animator>();
        animator.SetBool("isDead", true);
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
        return null;
    }
}
