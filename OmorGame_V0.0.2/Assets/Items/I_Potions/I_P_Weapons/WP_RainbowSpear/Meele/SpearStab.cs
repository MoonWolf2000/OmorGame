using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public  class SpearStab : I_P_A_Melee
{
    public bool HoldingSpear;

    protected override void Action()
    {
        base.Action();
        enemies.ForEach(e => e.GetComponent<Rigidbody2D>().AddForce(transform.position + Vector3.forward));
    }

}
