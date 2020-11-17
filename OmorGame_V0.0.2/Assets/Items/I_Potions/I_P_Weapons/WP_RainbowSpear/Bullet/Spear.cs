using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed  class Spear : I_P_W_Bullet
{
    private float _t;

    public override void WriteValues()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();

        _t = timeUsedToCalculateSpeed;
    }

    protected override void FixedUpdateOperations()
    {
        if (!isFlying) 
        {
            transform.position = transform.parent.position;
        return;
        
        } 

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Enemie>() && isFlying)
        {

            EnemyStatusChanger(collision.gameObject, EnemyStatusController.EnenemyStatus.b);

            Destroy(gameObject);
        }
    }

    private void OnDestroy()
    {
        GetComponentInParent<RainbowSpearPotion>().ReplaceSpear();
        Debug.Log("i fullfilled my duty" + enabled);
    }

    
}
