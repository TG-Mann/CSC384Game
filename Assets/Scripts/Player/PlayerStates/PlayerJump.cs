using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Callbacks;
using UnityEngine;

public class PlayerJump : IPlayerState
{
    private float jump = 4;
    private float horizontalMovement;
    private Animator animator; 

    private float speed = 2;

    private Rigidbody2D rb;

    public void Enter(Player player)
    {
        Debug.Log("Jump");
        rb = player.GetComponent<Rigidbody2D>();
        animator = player.GetComponent<Animator>();
        animator.SetBool("Jump", true);
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
