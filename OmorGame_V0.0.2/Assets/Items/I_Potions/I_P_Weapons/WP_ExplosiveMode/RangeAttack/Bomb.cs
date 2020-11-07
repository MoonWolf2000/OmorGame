using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public sealed class Bomb : I_P_W_Bullet
{
    Collider2D c2D;
    public float timeUntilExplosion;
    public bool isFlying;
    private float t;
    private float t1;
    [HideInInspector]public float timeForMovement;

    public void Explode()
    {
        
        c2D.enabled = true;

    }

    public override void WriteValues()
    {
        c2D = gameObject.GetComponent<Collider2D>();
        c2D.enabled = false;

        t = timeForMovement;
        t1 = timeUntilExplosion;
        base.WriteValues();
    }
    protected override void ForFixed()
    {
        t1 = t1 - Time.fixedDeltaTime;
        if (t1 <= 0)
        {
            Explode();
        }

        if (!isFlying) return;
        t = t - Time.fixedDeltaTime;
        rb.MovePosition(rb.position + direction * speed * Time.fixedDeltaTime);
        if (t <= 0)
        {
            isFlying = false;

        }

    }


    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<DamageToPlayerOnTouch>() == true)
        {
            collision.gameObject.GetComponent<LifeController>().lifechangers.Add(-dmg);
            Debug.Log(collision.name);
            Destroy(gameObject);


        }
    }
}
