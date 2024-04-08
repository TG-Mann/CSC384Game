using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDoubleJump : IPlayerState
{

    private float horizontalMovement;
    private Animator animator; 

    private Player self;

    private Rigidbody2D rb;

    public void Enter(Player player)
    {
        player.setPlayerState("DoubleJump");
        animator = player.GetComponent<Animator>();
        animator.SetBool("Jump", true);
        rb = player.GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(rb.velocity.x, player.getJump());
        rb.gravityScale = 1;
        self = player;
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
        rb.velocity = new Vector2(self.getSpeed() * horizontalMovement, rb.velocity.y);
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
