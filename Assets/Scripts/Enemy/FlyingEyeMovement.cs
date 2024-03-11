using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class FlyingEyeMovement : MonoBehaviour
{
    // Start is called before the first frame update
    private float speed;

    // Update is called once per frame
    void Awake()
    {
        speed = Random.Range(1,10);   
    }
    void FixedUpdate()
    {
        movePLatform();
    }

    private void movePLatform(){
        if (transform.position.x < 50){
            transform.position = new Vector2(transform.position.x + (speed / 100), transform.position.y);
        } else{
            Destroy(this.gameObject);
        }
    }
}
