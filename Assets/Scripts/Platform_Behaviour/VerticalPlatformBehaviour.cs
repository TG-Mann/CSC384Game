using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class VerticalPlatformBehaviour : MonoBehaviour
{
    [SerializeField] private float height;
    [SerializeField] private float depth;
    [SerializeField] private Vector2 speed;

    private string[] directions = {"up", "down"};

    private string direction;

    private Rigidbody2D rb;

    private void Awake(){

        rb = GetComponent<Rigidbody2D>();
        int random = Random.Range(0,2);
        direction = directions[random];
        
    }

    private void FixedUpdate(){
       
        updateMovement();
        UpdateDirection();
    
    }

    private void UpdateDirection(){
        if (rb.position.y > height & direction == "up"){
            direction = "down";
        }
        if (rb.position.y < depth & direction == "down"){
            direction = "up";
        }
    }

    private void updateMovement(){

           if (direction == "up"){
            rb.MovePosition(rb.position + speed);
        }
        else{
            rb.MovePosition(rb.position - speed);
        }

    }

}
