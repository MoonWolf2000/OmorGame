
﻿using UnityEngine;

public class I_P_W_Bullet : MonoBehaviour
{
    public float speed ;
    public Vector2 direction;
    public float timer = 0.0f;
    public float dmg;

    public Rigidbody2D rb;
    private void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }


    private void FixedUpdate()
    {
        if(timer> 0)
        timer = timer - Time.fixedDeltaTime;
        if (timer <= 0)
        {
        rb.MovePosition(rb.position + direction * speed * Time.fixedDeltaTime);

        }
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

