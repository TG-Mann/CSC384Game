using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWalk : IPlayerState
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
        if (Input.GetAxis("Horizontal") == 0){
            return new PlayerIdle();
        }
        return null;
    }

}
