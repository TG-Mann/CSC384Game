using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalItem : PowerUp
{
    public override void Activate(SpriteRenderer spriteRenderer)
    {
        EditRenderer(new Vector2(1.5f,1.5f), spriteRenderer, 1);
        setJump(4);
        setSpeed(2);
        setPlayerSize(Player.PlayerSize.normal);
        playerInvisible(false);
    }
}
