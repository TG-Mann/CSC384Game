using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrowItem : PowerUp
{
    public override void Activate(SpriteRenderer spriteRenderer)
    {
        EditRenderer(new Vector2(3f,3f), spriteRenderer, 1);
        setSpeed(1);
        setPlayerSize(Player.PlayerSize.large);
    }
    
}
