
using Sirenix.OdinInspector;
using UnityEngine;

public class I_P_W_Bullet : I_P_Attack
{

    public Vector2 direction;
    public float waitUntilMove = 0.0f;
    [Required]
    public Rigidbody2D rb;
    public bool isFlying;
    private float _t;




    protected virtual void Start()
    {
        WriteValues();
        _t = timeUsedToCalculateSpeed;
    }



    protected override void FixedUpdateOperations()
    {
        base.FixedUpdateOperations();

        if (waitUntilMove > 0)
            waitUntilMove = waitUntilMove - Time.fixedDeltaTime;
        if (waitUntilMove <= 0)
        {
            _t = _t - Time.fixedDeltaTime;
            rb.MovePosition(rb.position + direction * speed * Time.fixedDeltaTime);
            if (_t <= 0)
            {
                isFlying = false;

            }


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

