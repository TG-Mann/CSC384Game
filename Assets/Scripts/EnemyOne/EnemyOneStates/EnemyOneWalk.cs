using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyOneWalk : IEnemyOneState
{

    private Animator animator; 

    private int direction;

    private SpriteRenderer sprite;

    private float speed = 0.01f;

    private Vector2 startPoint;

    private Vector2 endPoint;

    EnemyOne self;

    public void Enter(EnemyOne enemyOne)
    {
        startPoint = new Vector2(enemyOne.getStartX(),enemyOne.getHeight());
        endPoint = new Vector2(enemyOne.getEndX(),enemyOne.getHeight());
        self = enemyOne;
        animator = enemyOne.GetComponent<Animator>();
        enemyOne.setEnemyOneState("Walk");
        animator.SetBool("isClose", true);
        direction = 1;
        sprite = enemyOne.GetComponent<SpriteRenderer>();
        if (!enemyOne.isDead()){
            sprite.flipX = false;
        }
    }

    public void Exit(EnemyOne enemyOne)
    {
        animator.SetBool("isClose", false);
    }

    public void frameUpdate()
    {
        
    }

    public void physicsUpdate()
    {
        checkPosition();
        move();
    }

    public IEnemyOneState Tick(EnemyOne enemyOne, Animator animator)
    {
        if (enemyOne.distanceToPlayer() > 15){
            return new EnemyOneIdle();
        }
        if (enemyOne.isDead()){
            return new EnemyOneDead();
        }
        if (enemyOne.distanceToPlayer() < 2.5 && enemyOne.getTimeSinceAttack() > 50){
            return new EnemyOneAttack();
        }
        return null;
    }

    private void checkPosition(){

        
        if (self.transform.position.x > endPoint.x){
            direction *= -1;
            sprite.flipX = true;
        }
        if (self.transform.position.x < startPoint.x){
            direction *= -1;
            sprite.flipX = false;
        }
        
    }

    private void move(){
        
        self.transform.position = new Vector2(self.transform.position.x + speed * direction, self.transform.position.y);
        
    }
}
