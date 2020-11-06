using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public sealed class Bomb : I_P_W_Bullet
{
    Collider2D c2D;
    public float timeUntilExplosion;
    public float MovementDuration;
    public bool isFlying;




    private float t;
    private float t1;
    private void Awake()
    {
        c2D = gameObject.GetComponent<Collider2D>();
        c2D.enabled = false;
        t = MovementDuration;
        t1 = timeUntilExplosion;
    }
    public void Explode()
    {
        
        c2D.enabled = true;
        Destroy(gameObject);

    }

    protected override void FixedUpdate()
    {
        t1 = t1 - Time.fixedDeltaTime;
        if(t1 <= 0)
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
            Destroy(gameObject);

        }
    }
}
