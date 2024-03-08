using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerAnimation : MonoBehaviour
{

    [SerializeField] private Animator animator; 
    
    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Awake()
    {

        rb = GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
       
        animator.SetFloat("XSpeed", math.abs(rb.velocity.x));
        
    }
}
