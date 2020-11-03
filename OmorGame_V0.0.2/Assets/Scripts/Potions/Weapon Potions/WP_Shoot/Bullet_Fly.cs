
﻿using UnityEngine;

public class Bullet_Fly : MonoBehaviour
{
    public float speed = 100f;
    public Vector2 direction;
    public int Bullet_dmg;
    public float timer = 0.2f;

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
            collision.gameObject.GetComponent<LifeController>().lifechangers.Add(-Bullet_dmg);
            Destroy(gameObject);

        }
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }


}

