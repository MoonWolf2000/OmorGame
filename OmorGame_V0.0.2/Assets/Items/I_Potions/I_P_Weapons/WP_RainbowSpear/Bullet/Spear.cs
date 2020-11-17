using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed  class Spear : I_P_W_Bullet
{
    private float _t;
    private void OnEnable()
    {
        WriteValues();
    }
    public override void WriteValues()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();

        _t = timeUsedToCalculateSpeed;
    }

    protected override void FixedUpdateOperations()
    {
        if (!isFlying) 
        {
            rb.MovePosition(transform.parent.position);
            return;
        
        }
        base.FixedUpdateOperations();

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Enemie>() && isFlying)
        {

            EnemyStatusChanger(collision.gameObject, EnemyStatusController.EnenemyStatus.b);

            Destroy(gameObject);
        }
    }


    private void OnDisable()
    {
        GetComponentInParent<RainbowSpearPotion>().ReplaceSpear();
        Debug.Log("sdfdfsfsadf");
    }


    
}
