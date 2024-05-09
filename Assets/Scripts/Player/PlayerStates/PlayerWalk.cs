using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerWalk : IPlayerState
{

    private Rigidbody2D rb;
    private Animator animator; 

    private float horizontalMovement;

    private Player self;

    public void Enter(Player player)
    {
        rb = player.GetComponent<Rigidbody2D>();
        animator = player.GetComponent<Animator>();
        animator.SetBool("Walk", true);
        rb.gravityScale = 1;
        self = player;
        player.setPlayerState("Walk");
        self.getWalkAudio().loop = true;
        self.getWalkAudio().Play();
        
    }

    public void Exit(Player player)
    {
        animator.SetBool("Walk", false);
        self.getWalkAudio().loop = false;
    }

    public void frameUpdate()
    {
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
        if (horizontalMovement == 0 && player.isGrounded()){
            return new PlayerIdle();
        }
        if(Input.GetKeyDown(KeyCode.Space) ){
            return new PlayerJump();
        }
        if(Input.GetKeyDown(KeyCode.LeftShift) && player.getDashCalldown() == 0  ){
            return new PlayerDash();
        }
        if(Input.GetKeyDown(KeyCode.Mouse0)){
            return new PlayerAttachOne();
        }
        if(Input.GetKeyDown(KeyCode.Mouse1)){
            return new PlayerAttachTwo();
        }
        if(Input.GetKeyDown(KeyCode.Q)){
            return new PlayerBlock();
        }
        if(Input.GetKeyDown(KeyCode.LeftControl)){
            return new PlayerRoll();
        }
        return null;
    }

   



}
