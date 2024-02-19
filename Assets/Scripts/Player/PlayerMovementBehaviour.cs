using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovementBehaviour : MonoBehaviour
{

    [SerializeField] private float speed;
    [SerializeField] private float dash = 0;
    [SerializeField] private float dashMultiplier = 4;

    [SerializeField] private float dashCooldown = 0;

    private Rigidbody2D rb;

    private float movement;

    // Start is called before the first frame update
    void Start()
    {

        rb = GetComponent<Rigidbody2D>();
        
    }

    void Update(){

        if (Input.GetKeyDown(KeyCode.LeftShift) && dash == 0 && dashCooldown == 0){
            speed = speed * dashMultiplier;
            dash = 100;
        }
       
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        movement = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(speed * movement, rb.velocity.y);

        updateDash();
        
    }

    void updateDash(){

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
}
