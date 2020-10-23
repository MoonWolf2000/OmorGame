using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Bullet_Fly : MonoBehaviour
{
    public float speed = 10f;
    public Vector2 direction;
    public Vector2 directionSign;

    public Vector2 startpos;
    public Rigidbody2D rb;

    private void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        startpos = gameObject.transform.position;
        directionSign = new Vector2(Mathf.Max(1,direction.x), Mathf.Max(1,direction.y));

    }

    private void ShootingDirection()
    {

    }


    private void FixedUpdate()
    {

        rb.MovePosition(rb.position + direction* speed * Time.fixedDeltaTime);
       // rb.velocity = (direction * speed * Time.fixedDeltaTime);
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
