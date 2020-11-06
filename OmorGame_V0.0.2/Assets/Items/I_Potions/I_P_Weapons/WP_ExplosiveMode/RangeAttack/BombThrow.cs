using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class BombThrow : I_P_A_Directional
{
    protected override void Action()
    {
        base.Action();
        clone.GetComponent<Bomb>().isFlying = true;
        
    }
}
