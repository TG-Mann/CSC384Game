using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthBar : MonoBehaviour
{
    [SerializeField] Player player;
    [SerializeField] private Image[] lives;
    
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
        

    }
}
