using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class PlayerDash : IPlayerState
{

    private Rigidbody2D rb;
    private Animator animator; 
    private float horizontalMovement;

    private int dashRemaining = 10;

    private float speed = 15;

    private int cooldownLength = 200;

    public void Enter(Player player)
    {
        rb = player.GetComponent<Rigidbody2D>();
        animator = player.GetComponent<Animator>();
        animator.SetBool("Dash", true);
        Debug.Log("Dash");
        
    }

    public void Exit(Player player)
    {
        
        animator.SetBool("Dash", false);
        player.setDashCalldown(cooldownLength);
    }

    public void frameUpdate()
    {
        horizontalMovement = Input.GetAxis("Horizontal");
       
    }

    public void physicsUpdate()
    {
        rb.velocity = new Vector2(speed * horizontalMovement, rb.velocity.y);
        updateDash();
    }

    private void updateDash(){

        if (dashRemaining > 0){
            dashRemaining -= 1;
        }

    }

    public IPlayerState Tick(Player player, Animator animator)
    {
        if (player.getHit()){
            return new PlayerHit();
        }
        if (dashRemaining == 0){
            if (horizontalMovement == 0){
                return new PlayerIdle();
            }
            if (horizontalMovement != 0){
                return new PlayerWalk();
            }
            if(Input.GetKeyDown(KeyCode.Space)){
                return new PlayerJump();
            }
        }
        if(Input.GetKeyDown(KeyCode.Q)){
            return new PlayerBlock();
        }
        return null;
    }
}
