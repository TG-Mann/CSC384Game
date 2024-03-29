using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEditor.ShaderGraph.Internal;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Player : MonoBehaviour
{
    private IPlayerState currentState = new PlayerIdle();

    [SerializeField] private Vector2 boxSize;
    [SerializeField] private Vector2 canMoveSize;
    [SerializeField] private float castDistance;
    [SerializeField] private float canMoveDistance;
    [SerializeField] private LayerMask groundLayer;

    [SerializeField] private LayerMask verticalLayer;
    [SerializeField] private LayerMask HorizontalLayer;
    [SerializeField] private Animator animator; 

    private int dashCooldown = 0;
    private float horizontalMovement;

    private string playerState;

    private bool direction = true;

    private bool isHit = false;

    private int numLives = 3;
    private SpriteRenderer sprite;

    void Awake()
    {
        sprite = GetComponent<SpriteRenderer>();
        setPlayerState("Idle");
    }

    void Update()
    {

        updateState();

        setDirection();

        currentState.frameUpdate();
        if (getLives() > 0){ // cant change direction when dead
            horizontalMovement = Input.GetAxis("Horizontal");
        }
        
        
    }

     void FixedUpdate()
    {

        currentState.physicsUpdate();

        if (dashCooldown > 0){
            dashCooldown -= 1;
        }


    } 
    private void setDirection(){
        if (horizontalMovement > 0 && !direction){
            sprite.flipX = false;
            direction = true;
        } 
        if (horizontalMovement < 0 && direction){
            sprite.flipX = true;
            direction = false;
        }
    }

    private void updateState(){

        IPlayerState newState = currentState.Tick(this, animator);

        if (newState != null){
            currentState.Exit(this);
            currentState = newState;
            newState.Enter(this);
        }
    }

    public int getDashCalldown(){
        return dashCooldown;
    }

    public void setDashCalldown(int newCooldown){
        dashCooldown = newCooldown;
    }

    public string getPLayerState(){
        return playerState;
    }

    public void setPlayerState(string newState){
        playerState = newState;
    }

    public bool isGrounded(){
       
        if (Physics2D.BoxCast(transform.position, boxSize, 0 , -transform.up, castDistance, groundLayer) || 
            Physics2D.BoxCast(transform.position, boxSize, 0 , -transform.up, castDistance, HorizontalLayer)){
            return true;
        } else{
            return false;
        }
    }

    


    private void OnDrawGizmos(){
        Gizmos.DrawWireCube(transform.position-transform.up * castDistance, boxSize);
        Gizmos.DrawWireCube(transform.position-transform.up * canMoveDistance, canMoveSize);
    }

    public bool getHit(){
        return isHit;
    }

    public void setHit(bool newHit){
        isHit = newHit;
    }

    public void takeLife(){
        numLives --;
    }

    public int getLives(){
        return numLives;
    }


}
