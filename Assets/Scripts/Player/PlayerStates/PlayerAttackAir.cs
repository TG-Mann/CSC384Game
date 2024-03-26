using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackAir : IPlayerState
{

    private Animator animator; 
    private Rigidbody2D rb;
    private float horizontalMovement;
    private float speed = 2;
    private BoxCollider2D bc;
    private float originalBCX;
    private float originalBCY;

    private int animationRunTime;

    public void Enter(Player player)
    {
        animator = player.GetComponent<Animator>();
        rb = player.GetComponent<Rigidbody2D>();
        rb.gravityScale = 1;
        animator.SetBool("AttackAir", true);
        bc = player.GetComponent<BoxCollider2D>();
        originalBCX = bc.size.x;
        originalBCY = bc.size.y;
        bc.size = new Vector2(1f, bc.size.y);
        Debug.Log("AttackAir");
    }

    public void Exit(Player player)
    {
        bc.size = new Vector2(originalBCX, originalBCY);
        animator.SetBool("AttackAir", false);
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
        if (horizontalMovement == 0 && player.isGrounded() && rb.velocity.y < 0.5){
            return new PlayerIdle();
        }
        if (horizontalMovement != 0 && player.isGrounded()){
            return new PlayerWalk();
        }
        return null;
    }
}