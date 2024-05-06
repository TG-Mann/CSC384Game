using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Callbacks;
using UnityEngine;

public class PlayerJump : IPlayerState
{
    private float horizontalMovement;
    private Animator animator; 

    private Rigidbody2D rb;

    private Player self;

    public void Enter(Player player)
    {
        player.setPlayerState("Jump");
        rb = player.GetComponent<Rigidbody2D>();
        animator = player.GetComponent<Animator>();
        animator.SetBool("Jump", true);
        self = player;
        rb.velocity = new Vector2(rb.velocity.x, player.getJump());
        rb.gravityScale = 1;
        player.getJumpAudio().Play();
            
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
        if (horizontalMovement != 0 && player.isGrounded() && rb.velocity.y < 0.5){
            return new PlayerWalk();
        }
         if(Input.GetKeyDown(KeyCode.Space)){
            return new PlayerDoubleJump();
        }
        if(Input.GetKeyDown(KeyCode.LeftShift) && player.getDashCalldown() == 0){
            return new PlayerDash();
        }
        
        return null;
    }

}
