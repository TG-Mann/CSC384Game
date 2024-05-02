using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

public class SaveObject
{
   public float playerX;
   public float playerY;

   public int numLives;

   public bool hasGhost;

   public bool hasSmall;

   public bool hasLarge;

   public SaveObject(float newPlayerX, float newPlayerY, int newNumLives, bool newHasGhost, bool newHasLarge, bool newHasSmall){
    setPlayerX(newPlayerX);
    setPlayerY(newPlayerY);
    setNumLives(newNumLives);
    setHasGhost(newHasGhost);
    setHasLarge(newHasLarge);
    setHasSmall(newHasSmall);

   }

    public void setPlayerX(float newPlayerX){
        playerX = newPlayerX;
    }

    public void setPlayerY(float newPlayerY){
        playerY = newPlayerY;
    }

   public void setNumLives(int newNumLives){
    numLives = newNumLives;
   }

   public void setHasGhost(bool newHasGhost){
    hasGhost = newHasGhost;
   }

   public void setHasLarge(bool newHasLarge){
    hasLarge = newHasLarge;
   }

   public void setHasSmall(bool newHasSmall){
    hasSmall = newHasSmall;
   }
}
