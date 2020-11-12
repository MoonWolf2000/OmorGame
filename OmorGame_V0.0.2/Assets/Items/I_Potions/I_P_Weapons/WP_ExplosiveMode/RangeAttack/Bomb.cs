using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using UnityEditor.Callbacks;
using UnityEngine;

public sealed class Bomb : I_P_W_Bullet
{
    Collider2D c2D;
    public float timeUntilExplosion;
    public float explosionsRadius;
    private float t;
    private float t1;
    private bool exploded;

    public void Explode()
    {
        
        //c2D.enabled = true;
        FindEnemiesAndDoDMG();
        exploded = true;
    }

    public override void WriteValues()
    {
        c2D = gameObject.GetComponent<Collider2D>();
        c2D.enabled = false;

        t = timeUsedToCalculateSpeed;
        t1 = timeUntilExplosion;
        base.WriteValues();
        exploded = false;

       
    }
    protected override void FixedUpdateOperations()
    {

        DebugDrawer();
        t1 = t1 - Time.fixedDeltaTime;
        if (t1 <= 0&& exploded == false)
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

    private void DebugDrawer()
    {
        Debug.DrawRay(transform.position, Vector2.up*explosionsRadius,Color.red);
        Debug.DrawRay(transform.position, Vector2.down*explosionsRadius,Color.red);
        Debug.DrawRay(transform.position, Vector2.right*explosionsRadius,Color.red);
        Debug.DrawRay(transform.position, Vector2.left*explosionsRadius,Color.red);
        Debug.DrawRay(transform.position, new Vector2(1,1).normalized*explosionsRadius,Color.red);
        Debug.DrawRay(transform.position, new Vector2(1,-1).normalized*explosionsRadius,Color.red);
        Debug.DrawRay(transform.position, new Vector2(-1,1).normalized*explosionsRadius,Color.red);
        Debug.DrawRay(transform.position, new Vector2(-1,-1).normalized*explosionsRadius,Color.red);
   
    }

    public void FindEnemiesAndDoDMG()
    {
     
       //List<LifeController> en = new List<LifeController>() ;
       // en.AddRange(FindObjectsOfType<LifeController>().Where(l => l.gameObject.GetComponent<Enemie>() == true).f(l => l.lifechangers.Add(-dmg)));
        FindObjectsOfType<LifeController>()
            .Where(l => l.gameObject.GetComponent<Enemie>() == true)
            .Where(l =>  Vector3.Distance(l.transform.position,transform.position) <= explosionsRadius)
            .Select(l => l.lifechangers).ToList()
            .ForEach(l => l.Add(-dmg));
        Destroy(gameObject);

    }


    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<DamageToPlayerOnTouch>() == true)
        {
            collision.gameObject.GetComponent<LifeController>().lifechangers.Add(-dmg);
            Debug.Log(collision.name);


        }
            Destroy(gameObject);
    }
}
