using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class PlayerMenuBehaviour : MonoBehaviour
{

    private Rigidbody2D rb;
    private Animator animator;
    // Start is called before the first frame update
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        animator.SetBool("Walk",true);
    }
   

    // Update is called once per frame
    void FixedUpdate()
    {
       transform.position = new Vector2(transform.position.x + 0.04f, transform.position.y);
       if (transform.position.x > 10){
            transform.position = new Vector2(-9.5f, -0.4f);
       }
    }
}
