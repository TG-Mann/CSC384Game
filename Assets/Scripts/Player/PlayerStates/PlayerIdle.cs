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
        Debug.Log("Idle");
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
        if (Input.GetAxis("Horizontal") != 0){
            return new PlayerWalk();
        }
        
        if(Input.GetKeyDown(KeyCode.Space)){
            return new PlayerJump();
        }
        
        if(Input.GetKeyDown(KeyCode.LeftShift) && player.getDashCalldown() == 0){
            return new PlayerDash();
        }

        return null;
    }   

    
}