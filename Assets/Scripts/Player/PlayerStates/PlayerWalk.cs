using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;


public class PlayerWalk : IPlayerState
{

    private Rigidbody2D rb;
    private Animator animator; 

    private float horizontalMovement;

    private float speed = 2;

    public void Enter(Player player)
    {
        rb = player.GetComponent<Rigidbody2D>();
        animator = player.GetComponent<Animator>();
        animator.SetBool("Walk", true);
        rb.gravityScale = 1;
        Debug.Log("Walk");
        return;
    }

    public void Exit(Player player)
    {
        animator.SetBool("Walk", false);
    }

    public void frameUpdate()
    {
        horizontalMovement = Input.GetAxis("Horizontal");
        
    }

    public void physicsUpdate()
    {
        rb.velocity = new Vector2(speed * horizontalMovement, rb.velocity.y);
    }

    public IPlayerState Tick(Player player, Animator animator)
    {
        if (horizontalMovement == 0 && player.isGrounded()){
            return new PlayerIdle();
        }
        if(Input.GetKeyDown(KeyCode.Space)){
            return new PlayerJump();
        }
        if(Input.GetKeyDown(KeyCode.LeftShift) && player.getDashCalldown() == 0){
            return new PlayerDash();
        }
        return null;
    }

   



}
