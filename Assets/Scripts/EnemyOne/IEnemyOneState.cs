using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IEnemyOneState
{
   public IEnemyOneState Tick(EnemyOne enemyOne, Animator animator);
   public void Enter(EnemyOne enemyOne);
   public void Exit(EnemyOne enemyOne);

   public void frameUpdate();

   public void physicsUpdate();
}
