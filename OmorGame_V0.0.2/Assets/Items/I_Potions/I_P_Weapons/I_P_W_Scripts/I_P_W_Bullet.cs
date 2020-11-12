
﻿using UnityEngine;

public class I_P_W_Bullet : I_P_Attack
{
    
    public Vector2 direction;
    public float waitUntilMove = 0.0f;
    public Rigidbody2D rb;
    public bool isFlying;



    
protected virtual void Start()
    {
      
        WriteValues();

        
    }



    protected override void FixedUpdateOperations()
    {
        base.FixedUpdateOperations();
   
        if (waitUntilMove > 0)
            waitUntilMove = waitUntilMove - Time.fixedDeltaTime;
        if (waitUntilMove <= 0)
        {
            rb.MovePosition(rb.position + direction * speed * Time.fixedDeltaTime);

        }
    }

     public virtual void WriteValues()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
  
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<DamageToPlayerOnTouch>() == true)
        {
            collision.gameObject.GetComponent<LifeController>().lifechangers.Add(-dmg);
            Destroy(gameObject);

        }
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }


}

