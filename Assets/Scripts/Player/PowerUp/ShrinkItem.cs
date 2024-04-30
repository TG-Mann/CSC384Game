using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShrinkItem : PowerUp
{
    public override void Activate(SpriteRenderer spriteRenderer)
    {
        EditRenderer(new Vector2(0.8f,0.8f), spriteRenderer, 1);
        setJump(6);
        setSpeed(5);
        setPlayerSize(Player.PlayerSize.small);
    }

}
