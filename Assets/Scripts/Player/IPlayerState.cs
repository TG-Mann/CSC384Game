using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPlayerState
{
   public IPlayerState Tick(Player player, Animator animator);
   public void Enter(Player player);
   public void Exit(Player player);

   public void frameUpdate();

   public void physicsUpdate();
}
