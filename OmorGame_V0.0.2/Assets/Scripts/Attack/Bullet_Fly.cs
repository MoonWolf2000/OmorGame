
﻿using UnityEngine;

public class Bullet_Fly : MonoBehaviour
{
    public float speed = 100f;
    public Vector2 direction;

    public Rigidbody2D rb;
    private void Start()
    {
        Debug.Log("Iwann save rigifbody");
        rb = gameObject.GetComponent<Rigidbody2D>();
    }


    private void FixedUpdate()
    {

        rb.MovePosition(rb.position + direction * speed * Time.fixedDeltaTime);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<DamageToPlayerOnTouch>() == true)
        {
            collision.gameObject.GetComponent<LifeController>().lifechangers.Add(-1);
            Destroy(gameObject);

        }
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }


}

