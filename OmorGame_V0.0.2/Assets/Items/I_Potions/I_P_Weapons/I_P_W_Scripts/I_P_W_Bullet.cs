
﻿using UnityEngine;

public class I_P_W_Bullet : MonoBehaviour
{
    
    public Vector2 direction;
    public float waitUntilMove = 0.0f;
    public float dmg = 1;
    public Rigidbody2D rb;
    public float speed;


    
protected virtual void Start()
    {
      
        WriteValues();

        
    }


    protected virtual void FixedUpdate()
    {
        ForFixed();

    }

    protected  virtual void ForFixed()
    {
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

