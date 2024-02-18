using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovementBehaviour : MonoBehaviour
{

    [SerializeField] private float speed;

    private Rigidbody2D rb;

    private float movement;

    // Start is called before the first frame update
    void Start()
    {

        rb = GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        movement = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(speed * movement, rb.velocity.y);
    }
}
