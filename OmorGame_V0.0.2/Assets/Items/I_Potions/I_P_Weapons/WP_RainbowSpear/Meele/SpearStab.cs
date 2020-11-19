using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

public  class SpearStab : I_P_A_Melee
{
    public bool HoldingSpear;
    public float cooldownBecauseOfAura;

  
    [ShowInInspector,ReadOnly]
    private float _t2 = 0;
    [ShowInInspector,ReadOnly]
    private bool allowdToStab = true;
    protected override void Action()
    {
        if (!allowdToStab) return;
        Debug.Log("allomwent");
        base.Action();
        enemies.ForEach(e => e.transform.GetComponent<Rigidbody2D>()
        .AddForce(PlayerMoveController.directions[transform.parent.parent.GetComponent<PlayerMoveController>().futureDirection]  * 100));
        enemies.ForEach(e => e.transform.GetComponent<GeneralEnemyMovementFollowPlayer>().moving = false);
        
    }
    public void refillTimer()
    {
        _t2 = cooldownBecauseOfAura;
    Debug.Log("sdjfaskljdfasdfj");
            
            }

    protected override void FixedUpdateOperations()
    {
        base.FixedUpdateOperations();
        _t2.ToZeroTimer();
        allowdToStab = (_t2 == 0 ? true : false);
    }

}
