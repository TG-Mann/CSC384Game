using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Unity.VisualScripting;
using UnityEditor;
using UnityEditor.Callbacks;
using UnityEngine;

public class PlayerIdle : IPlayerState
{

    public void Enter(Player player)
    {
        player.setPlayerState("Idle");
        return;
    }

    public void Exit(Player player)
    {
        return;
    }

    public void frameUpdate()
    {
        return;
    }

    public void physicsUpdate()
    {
        return;
    }

    public IPlayerState Tick(Player player, Animator animator)
    {   
        if (player.getHit()){
            return new PlayerHit();
        }
        if (Input.GetAxis("Horizontal") != 0){
            return new PlayerWalk();
        }
        
        if(Input.GetKeyDown(KeyCode.Space)){
            return new PlayerJump();
        }
        
        if(Input.GetKeyDown(KeyCode.LeftShift) && player.getDashCalldown() == 0){
            return new PlayerDash();
        }
        if(Input.GetKeyDown(KeyCode.Mouse0)){
            return new PlayerAttachOne();
        }
        if(Input.GetKeyDown(KeyCode.Mouse1)){
            return new PlayerAttachTwo();
        }
        if(Input.GetKeyDown(KeyCode.Q)){
            return new PlayerBlock();
        }

        return null;
    }   

    
}
