using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyOneAttack : IEnemyOneState
{
    private Animator animator;

    private SpriteRenderer sprite;

    private int attackTime;

    GameObject player;

    public void Enter(EnemyOne enemyOne)
    {
        animator = enemyOne.GetComponent<Animator>();
        player = GameObject.FindWithTag("Player");
        sprite = enemyOne.GetComponent<SpriteRenderer>();
        enemyOne.setEnemyOneState("Attack");
        animator.SetBool("AttackOne", true);
        setSpritePosition(enemyOne);

    }

    public void Exit(EnemyOne enemyOne)
    {
         animator.SetBool("AttackOne", false);
         enemyOne.setTimeSinceAttack(0);
    }

    public void frameUpdate()
    {
        
    }

    public void physicsUpdate()
    {
        attackTime ++;
    }

    public IEnemyOneState Tick(EnemyOne enemyOne, Animator animator)
    {
        if (attackTime > 50){
            return new EnemyOneIdle();
        }
        return null;
    }

    private void setSpritePosition(EnemyOne enemyOne){
        if (player.transform.position.x < enemyOne.transform.position.x){
            sprite.flipX = true;
        }
    }

}
