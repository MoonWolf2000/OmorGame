using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class WP_Sword : WeaponPotion
{
    bool attacking;
    Vector3 offset;

    private void Awake()
    {
        attacking = false;
        time = 90;
        dmg = 15;
        offset = new Vector3(0, 2f, 0);
    }

    private void Update()
    {if (time > 0)
        {
        time--;

        }
    }

    private void FixedUpdate()
    {
      
    }

    public override void Attack(InputAction.CallbackContext contex)
    {
        if (attacking) return;
        time = 90;

        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
      //  if (!attacking) return;
        if (collision.gameObject.GetComponent<DamageToPlayerOnTouch>() == true)
        {
            collision.gameObject.GetComponent<LifeController>().lifechangers.Add(-Convert.ToInt32( dmg));
          

        }
    }
 
}
