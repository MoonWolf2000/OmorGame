using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class WP_Sword : I_P_W_Standart
{
    bool attacking;
    Vector3 offset;

    private void Awake()
    {
        attacking = false;
        offset = new Vector3(0, 2f, 0);
    }

    private void Update()
    {

    }

    private void FixedUpdate()
    {
      
    }

    protected override void DirectionelAttack(InputAction.CallbackContext contex)
    {
        if (attacking) return;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<DamageToPlayerOnTouch>() == true)
        {
            collision.gameObject.GetComponent<LifeController>().lifechangers.Add(-Convert.ToInt32( dmg));
          

        }
    }
 
}
