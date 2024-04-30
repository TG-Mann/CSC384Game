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

    public enum PlayerSize{small, normal, large}

    private PlayerSize playerSize = PlayerSize.normal;

    [SerializeField] private PhysicsMaterial2D grip;

    [SerializeField] private PlayerCollision playerCollision;

    private int speed = 2;

    private int jump = 4;

    private int dashCooldown = 0;
    private float horizontalMovement;

    private string playerState;

    private bool isInvisible = false;

    private bool direction = true;

    private bool isHit = false;

    private int numLives = 3;

    private float extra = 1;
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

    public int getSpeed(){
        return speed;
    }

    public void setSpeed(int newSpeed){
        speed = newSpeed;
    }

    public int getJump(){
        return jump;
    }

    public void setJump(int newJump){
        jump = newJump;
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
        
        if (playerSize == PlayerSize.large){
           extra = 2;
        } else if (playerSize == PlayerSize.small){
            extra = 0.5f;
        } else{
            extra = 1;
        }
        if (Physics2D.BoxCast(transform.position, boxSize, 0 , -transform.up, castDistance * extra, groundLayer) || 
            Physics2D.BoxCast(transform.position, boxSize, 0 , -transform.up, castDistance * extra, HorizontalLayer)){
            return true;
        } else{
            return false;
        }
    }

    public void setPlayerSize(PlayerSize newSize){
        playerSize = newSize;
    }

    public PlayerSize getPlayerSize(){
        return playerSize;
    }

    private void OnDrawGizmos(){
        Gizmos.DrawWireCube(transform.position-transform.up * castDistance * extra, boxSize);
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

    public bool getIsInvisible(){
        return isInvisible;
    }

    public void setIsInvisible(bool newInvicible){
        isInvisible = newInvicible;
    }


}
