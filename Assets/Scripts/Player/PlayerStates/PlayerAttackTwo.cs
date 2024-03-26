using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttachTwo : IPlayerState
{
    private Animator animator; 

    private Rigidbody2D rb;

    private BoxCollider2D bc;

    private int animationRunTime;

    private float horizontalMovement;

    private float speed = 2;

    private float originalBCX;
    private float originalBCY;

    public void Enter(Player player)
    {
        animator = player.GetComponent<Animator>();
        rb = player.GetComponent<Rigidbody2D>();
        animator.SetBool("AttackTwo",true);
        rb.gravityScale = 1;
        bc = player.GetComponent<BoxCollider2D>();
        originalBCX = bc.size.x;
        originalBCY = bc.size.y;
        bc.size = new Vector2(1.2f, bc.size.y);
        Debug.Log("AttackTwo");
    }

    public void Exit(Player player)
    {
        bc.size = new Vector2(originalBCX, originalBCY);
        animator.SetBool("AttackTwo",false);
        
    }

    public void frameUpdate()
    {
        horizontalMovement = Input.GetAxis("Horizontal");
    }

    public void physicsUpdate()
    {
        animationRunTime ++;
        rb.velocity = new Vector2(speed * horizontalMovement, rb.velocity.y);
    }

    public IPlayerState Tick(Player player, Animator animator)
    {
        if (animationRunTime > 32){
            return new PlayerIdle();
        }
        if(Input.GetKeyDown(KeyCode.Q)){
            return new PlayerBlock();
        }
        return null;
    }

}
