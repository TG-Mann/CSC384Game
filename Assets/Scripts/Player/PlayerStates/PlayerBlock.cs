using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBlock : IPlayerState
{

    private Animator animator;

    public void Enter(Player player)
    {
        animator = player.GetComponent<Animator>();
        animator.SetBool("Block",true);
        Debug.Log("Block");
        
    }

    public void Exit(Player player)
    {
        animator.SetBool("Block",false);
    }

    public void frameUpdate()
    {
        
    }

    public void physicsUpdate()
    {
        
    }

    public IPlayerState Tick(Player player, Animator animator)
    {
        if (Input.GetKeyUp(KeyCode.Q)){
            return new PlayerIdle();
        }

        return null;
    }
}
