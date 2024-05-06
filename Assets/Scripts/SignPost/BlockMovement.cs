using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockMovement : MonoBehaviour
{

    [SerializeField] GameObject blocker;

    public void OnTriggerEnter2D(Collider2D collision){

        if (collision.gameObject.CompareTag("Player")){
          
          blockPlayer();
          
        } 

    }

    void blockPlayer(){
        blocker.SetActive(true);
    }
}
