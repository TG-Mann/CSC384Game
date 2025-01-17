using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class VerticalPlatformBehaviour : MonoBehaviour
{
    [SerializeField] private float speed;

    [SerializeField] private Vector2 startPoint;

    [SerializeField] private Vector2 endPoint;

    [SerializeField] private bool isVertical;

    private int[] choices = {-1, 1};

    private int direction;

    private Rigidbody2D platform;

    private void Awake(){

        platform = GetComponent<Rigidbody2D>();

        int random = Random.Range(0,2);
      
        direction = choices[random];
     
    }

    void FixedUpdate(){
        
        checkPosition();
        movePLatform();

    }  

    private void movePLatform(){
        if (isVertical){
            transform.position = new Vector2(transform.position.x, transform.position.y + speed * direction);
        } else{
            transform.position = new Vector2(transform.position.x + speed * direction, transform.position.y);
        }
    }

    private void checkPosition(){

        if (isVertical){
            if (transform.position.y > endPoint.y){
                direction *= -1;
            }
            if (transform.position.y < startPoint.y){
                direction *= -1;
            }
        } else{
            if (transform.position.x > endPoint.x){
                direction *= -1;
            }
            if (transform.position.x < startPoint.x){
                direction *= -1;
            }
        }
    }


}
