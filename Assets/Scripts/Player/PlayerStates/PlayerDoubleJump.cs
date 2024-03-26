using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDoubleJump : IPlayerState
{

    private float jump = 4;
    private float horizontalMovement;
    private float speed = 2;
    private Animator animator; 

    private Rigidbody2D rb;

    public void Enter(Player player)
    {
        Debug.Log("DoubleJump");
        animator = player.GetComponent<Animator>();
        animator.SetBool("Jump", true);
        rb = player.GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(rb.velocity.x, jump);
        rb.gravityScale = 1;
    }

    public void Exit(Player player)
    {
        animator.SetBool("Jump", false);
    }

    public void frameUpdate()
    {
         if (rb.velocity.y < 0){
            rb.gravityScale = 2;
        } 
        horizontalMovement = Input.GetAxis("Horizontal");
    }

    public void physicsUpdate()
    {
        rb.velocity = new Vector2(speed * horizontalMovement, rb.velocity.y);
    }

    public IPlayerState Tick(Player player, Animator animator)
    {
        if (player.getHit()){
            return new PlayerHit();
        }
        if (horizontalMovement == 0 && player.isGrounded() && rb.velocity.y < 0.5){
            return new PlayerIdle();
        }
         if (horizontalMovement != 0 && player.isGrounded()){
            return new PlayerWalk();
        }
        if(Input.GetKeyDown(KeyCode.LeftShift) && player.getDashCalldown() == 0){
            return new PlayerDash();
        }
         if (Input.GetKeyDown(KeyCode.Mouse1) || Input.GetKeyDown(KeyCode.Mouse0)){
            return new PlayerAttackAir();
        }
        return null;
    }
}
