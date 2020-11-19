using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public  class SpearStab : I_P_A_Melee
{
    public bool HoldingSpear;
    protected override void Action()
    {
        base.Action();
        enemies.ForEach(e => e.transform.GetComponent<Rigidbody2D>()
        .AddForce(PlayerMoveController.directions[transform.parent.parent.GetComponent<PlayerMoveController>().futureDirection]  * 100));
        enemies.ForEach(e => e.transform.GetComponent<GeneralEnemyMovementFollowPlayer>().moving = false);
       
    }

}
