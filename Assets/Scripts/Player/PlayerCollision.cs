using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerCollision : MonoBehaviour
{

     private Rigidbody2D rb;

    void Awake()
    {

        rb = GetComponent<Rigidbody2D>();
        
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.CompareTag("HorizontalPlatform")){

           this.transform.parent = collision.transform;
          
        } 
    }

    public void OnCollisionExit2D(Collision2D collision){
        if (collision.gameObject.CompareTag("HorizontalPlatform")){
            this.transform.parent = null;
        }
    }
}
