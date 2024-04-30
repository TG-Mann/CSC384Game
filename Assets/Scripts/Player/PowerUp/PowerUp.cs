using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PowerUp
{

    Player player = GameObject.FindAnyObjectByType<Player>();
    public abstract void Activate(SpriteRenderer spriteRenderer);  // could add ghost thing by chnaging translucent // use this to deactivate as well

    protected void EditRenderer(Vector2 newSize, SpriteRenderer spriteRenderer, float transparency){
        spriteRenderer.transform.localScale = newSize;   
        spriteRenderer.material.color = new Color(spriteRenderer.material.color.r, spriteRenderer.material.color.g, spriteRenderer.material.color.b, transparency);
    }

    protected void setSpeed(int newSpeed){
        player.setSpeed(newSpeed);
    }

    protected void setJump(int newJump){
        player.setJump(newJump);
    }

    protected void setPlayerSize(Player.PlayerSize newPlayerSize){
        player.setPlayerSize(newPlayerSize);
    }

    protected void playerInvisible(bool newInvicible){
        
        player.setIsInvisible(newInvicible);
    }



}
