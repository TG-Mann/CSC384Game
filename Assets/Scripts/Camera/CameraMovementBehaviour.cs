using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovementBehaviour : MonoBehaviour
{
    private bool move = false;

    private float xPos;

    private float yPos;

    [SerializeField] Player player;
    public void FixedUpdate(){
        if (move){       
            if((player.transform.position.x - this.transform.position.x) > 10){
                transform.position = Vector3.MoveTowards(transform.position, new Vector3(xPos, yPos, transform.position.z), 10f);
            } else{
                transform.position = Vector3.MoveTowards(transform.position, new Vector3(xPos, yPos, transform.position.z), 0.1f);
            }
            
        }
    }

    IEnumerator waitTime(){     
        yield return new WaitForSeconds(5f);    
    }

    public void moveCamera(float x, float y){
        move = true;
        xPos = x;
        yPos = y;

      
        
    }

    
}





