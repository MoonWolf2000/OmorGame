using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed  class Spear : I_P_W_Bullet
{
    private float _t;

    public override void WriteValues()
    {
        _t = timeUsedToCalculateSpeed;
    }

    protected override void FixedUpdateOperations()
    {
        if (!isFlying) return;
        _t = _t - Time.fixedDeltaTime;
        base.FixedUpdateOperations();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Enemie>())
        {

            EnemyStatusChanger(collision.gameObject, EnemyStatusController.EnenemyStatus.b);

            Destroy(gameObject);
        }
    }
}
