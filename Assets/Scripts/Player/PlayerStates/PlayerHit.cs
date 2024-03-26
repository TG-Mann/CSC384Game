using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerHit : IPlayerState
{

    private Animator animator; 
    
    private int animationRunTime;

    private BoxCollider2D bc;

    public void Enter(Player player)
    {
        animator = player.GetComponent<Animator>();
        Debug.Log("Hit");
        bc = player.GetComponent<BoxCollider2D>();
        animator.SetBool("Hit",true);
        player.takeLife();
    }

    public void Exit(Player player)
    {
        player.setHit(false);
        animator.SetBool("Hit",false);
    }

    public void frameUpdate()
    {
        
    }

    public void physicsUpdate()
    {
        animationRunTime ++;
    }

    public IPlayerState Tick(Player player, Animator animator)
    {
        if (animationRunTime > 15 && player.getLives() != 0){
            return new PlayerIdle();
        }
        if (player.getLives() == 0){
            playerDeath();
        }
        return null;
    }

    private void playerDeath(){
        bc.offset = new Vector2(bc.offset.x, -0.18f);
        animator.SetBool("Hit",false);
        animator.SetBool("Dead",true);
    }
}
