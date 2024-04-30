using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthBar : MonoBehaviour
{
    [SerializeField] Player player;

    [SerializeField] PlayerCollision playerCollision;

    [SerializeField] private Image[] lives;

    [SerializeField] private Image[] powerUp;
    
    void FixedUpdate(){
        if (player.getLives() == 2){
            lives[0].enabled = true;
            lives[1].enabled = true;
            lives[2].enabled = false;
        }
        else if (player.getLives() == 1){
            lives[0].enabled = true;
            lives[1].enabled = false;
            lives[2].enabled = false;
        }
        else if (player.getLives() == 0){
            lives[0].enabled = false;
            lives[1].enabled = false;
            lives[2].enabled = false;
        } 
        else{
            lives[0].enabled = true;
            lives[1].enabled = true;
            lives[2].enabled = true;
        }
        
        if (playerCollision.getHasInvicibleItem()){
            powerUp[0].enabled = true;
        } else{
            powerUp[0].enabled = false;
        }

        if (playerCollision.getHasLargeItem()){
            powerUp[1].enabled = true;
        } else{
            powerUp[1].enabled = false;
        }

        if (playerCollision.getHasSmallItem()){
            powerUp[2].enabled = true;
        } else{
            powerUp[2].enabled = false;
        }
        
    }
}
