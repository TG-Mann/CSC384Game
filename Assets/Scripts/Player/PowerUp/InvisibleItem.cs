using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvisibleItem : PowerUp
{
    public override void Activate(SpriteRenderer spriteRenderer)
    {
        EditRenderer(new Vector2(1.5f,1.5f), spriteRenderer, 0.4f);
        playerInvisible(true);
    }
}
