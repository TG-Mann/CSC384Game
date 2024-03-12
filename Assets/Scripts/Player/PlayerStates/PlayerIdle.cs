using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEditor;
using UnityEngine;

public class PlayerIdle : IPlayerState
{
    public void Enter(Player player)
    {
        return;
    }

    public void Exit(Player player)
    {
        return;
    }

    public IPlayerState Tick(Player player)
    {   
       
        if (Input.GetAxis("Horizontal") != 0){
            return new PlayerWalk();
        }
        return null;
    }

  
}
