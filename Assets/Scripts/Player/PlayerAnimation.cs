using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerAnimation : MonoBehaviour
{

    float previous;
    [SerializeField] private Animator animator; 
    
    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Awake()
    {

        rb = GetComponent<Rigidbody2D>();
        
    }

    //DASH is assigned in PlayerMovementBehaviour

    // Update is called once per frame
    void Update()
    {
       
        animator.SetFloat("XSpeed", math.abs(rb.velocity.x));

        if (rb.velocity.y > 0.5 && animator.GetBool("Dash") != true){
            animator.SetBool("Jump", true);
        } 

        if (rb.velocity.y == 0){
            animator.SetBool("Jump", false);
        }
      
    }
}
