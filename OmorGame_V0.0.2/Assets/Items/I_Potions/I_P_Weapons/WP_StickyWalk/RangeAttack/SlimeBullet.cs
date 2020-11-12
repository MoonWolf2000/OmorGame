using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeBullet : I_P_W_Bullet
{

    Collider2D c2D;
    public float timeUntilExplosion;
    public float explosionsRadius;
    public GameObject prefabSlimePuddle;
    private GameObject _slimespot;
    private float _t;
    private float _tte;
    private bool _exploded;



    public void Explode()
    {
        CreateSlimespot();
        Destroy(gameObject);
        _exploded = true;
    }

    public void CreateSlimespot()
    {
        _slimespot = Instantiate(prefabSlimePuddle, transform.position, transform.rotation);
    }

    public override void WriteValues()
    {
        c2D = gameObject.GetComponent<Collider2D>();
   

        _t = timeUsedToCalculateSpeed;
        _tte = timeUntilExplosion;
        base.WriteValues();
        _exploded = false;


    }
    protected override void FixedUpdateOperations()
    {

        DebugDrawer();
        _tte = _tte - Time.fixedDeltaTime;
        if (_tte <= 0 && _exploded == false)
        {
            Explode();
        }

        if (!isFlying) return;
        _t = _t - Time.fixedDeltaTime;
        rb.MovePosition(rb.position + direction * speed * Time.fixedDeltaTime);
        if (_t <= 0)
        {
            isFlying = false;
            Explode();

        }

    }

    private void DebugDrawer()
    {
        Debug.DrawRay(transform.position, Vector2.up * explosionsRadius, Color.red);
        Debug.DrawRay(transform.position, Vector2.down * explosionsRadius, Color.red);
        Debug.DrawRay(transform.position, Vector2.right * explosionsRadius, Color.red);
        Debug.DrawRay(transform.position, Vector2.left * explosionsRadius, Color.red);
        Debug.DrawRay(transform.position, new Vector2(1, 1).normalized * explosionsRadius, Color.red);
        Debug.DrawRay(transform.position, new Vector2(1, -1).normalized * explosionsRadius, Color.red);
        Debug.DrawRay(transform.position, new Vector2(-1, 1).normalized * explosionsRadius, Color.red);
        Debug.DrawRay(transform.position, new Vector2(-1, -1).normalized * explosionsRadius, Color.red);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Enemie>())
        {

        EnemyStatusChanger(collision.gameObject, EnemyStatusController.EnenemyStatus.b);

Destroy(gameObject);
        }
    }


}
