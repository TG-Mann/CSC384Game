using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovementBehaviour : MonoBehaviour
{

    [SerializeField] private float speed;
    [SerializeField] private float dash = 0;
    [SerializeField] private float dashMultiplier = 4;

    [SerializeField] private float dashCooldown = 0;

    [SerializeField] private float jump;

    [SerializeField] private Vector2 boxSize;

    [SerializeField] private float castDistance;

    [SerializeField] private LayerMask groundLayer;
    private Rigidbody2D rb;

    private float movement;

    private int numJumps;

    // Start is called before the first frame update
    void Start()
    {

        rb = GetComponent<Rigidbody2D>();
        
    }

    void Update(){

        detectDash();
        
        numJumps = playerJump(numJumps);
       
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        movement = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(speed * movement, rb.velocity.y);

        updateDash();

    }

    private void updateDash(){

         if (dash == 1){
            dash -= 1;
            speed = speed/dashMultiplier;
            dashCooldown = 400;
        } 
        if (dash > 1){
            dash -= 1;
        }
        if (dashCooldown != 0){
            dashCooldown -= 1;
        }

    }

    private void detectDash(){
         if (Input.GetKeyDown(KeyCode.LeftShift) && dash == 0 && dashCooldown == 0){
            speed = speed * dashMultiplier;
            dash = 100;
        }
    }

    private int playerJump(int numJumps){
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded(numJumps)){
            rb.velocity = new Vector2(rb.velocity.x, jump);
            return numJumps = 1;
          
        }
        if (Input.GetKeyDown(KeyCode.Space) && !isGrounded(numJumps) && numJumps == 1){
            rb.velocity = new Vector2(rb.velocity.x, jump);
            return numJumps = 2;
        }
        else{
            return numJumps;
        }
    }

    private bool isGrounded(int numJumps){
        if (Physics2D.BoxCast(transform.position, boxSize, 0 , -transform.up, castDistance, groundLayer)){
            numJumps = 0;
            return true;
        } else{
            return false;
        }
    }

    private void OnDrawGizmos(){
        Gizmos.DrawWireCube(transform.position-transform.up * castDistance, boxSize);
    }


}
