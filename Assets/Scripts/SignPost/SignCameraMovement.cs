using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SignCameraMovement : MonoBehaviour
{   

    [SerializeField] float x;
    [SerializeField] float y;

    [SerializeField] private GameObject levelMessage;

    [SerializeField] CameraMovementBehaviour script;
    public void OnTriggerEnter2D(Collider2D collision){

        if (collision.gameObject.CompareTag("Player")){
            script.moveCamera(x,y);
            levelMessage.SetActive(true);
            StartCoroutine("Wait");
          
        } 

    }

     IEnumerator Wait(){
        yield return new WaitForSeconds(2f);
        levelMessage.SetActive(false);
        
    }

}
