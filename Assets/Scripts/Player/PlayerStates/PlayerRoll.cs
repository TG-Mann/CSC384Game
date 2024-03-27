using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRoll : IPlayerState
{

    private Animator animator; 
    private Rigidbody2D rb;
    private BoxCollider2D bc;

    private int animationRunTime;

    private float horizontalMovement;

    private float speed = 2;

    private float originalBCX;
    private float originalBCY;

    private float offsetBCX;
    private float offsetBCY;


    public void Enter(Player player)
    {
        animator = player.GetComponent<Animator>();
        rb = player.GetComponent<Rigidbody2D>();
        animator.SetBool("Roll",true);
        rb.gravityScale = 1;
        bc = player.GetComponent<BoxCollider2D>();
        originalBCX = bc.size.x;
        originalBCY = bc.size.y;
        offsetBCX = bc.offset.x;
        offsetBCY = bc.offset.y;
        bc.size = new Vector2(bc.size.x, 0.4f);
        bc.offset = new Vector2(bc.offset.x, -0.1f);
        player.setPlayerState("Roll");
    }

    public void Exit(Player player)
    {
        bc.size = new Vector2(originalBCX, originalBCY);
        bc.offset = new Vector2(offsetBCX, offsetBCY);
        animator.SetBool("Roll",false);
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
        if (player.getHit()){
            return new PlayerHit();
        }
        if (animationRunTime > 30){
            return new PlayerWalk();  
        }
        
        return null;
    }
}
