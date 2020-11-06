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
    private void Awake()
    {
        c2D = gameObject.GetComponent<Collider2D>();
        c2D.enabled = false;
    }
    public void Explode()
    {
        c2D.enabled = true;

    }

    public Vector2 Moving()
    {

        return rb.position + direction * speed * Time.fixedDeltaTime;
    }
    protected override void FixedUpdate()
    {
    
        if (!isFlying) return;
    
        t = t - Time.fixedDeltaTime;
        rb.MovePosition(Moving());
        if (t <= 0)
        {
            isFlying = false;
            Explode();
        }
    }


}
