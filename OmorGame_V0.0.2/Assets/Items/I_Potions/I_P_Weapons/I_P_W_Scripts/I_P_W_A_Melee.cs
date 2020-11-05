using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class I_P_W_A_Melee : I_P_W_Attack
{
    private List<GameObject> enemie = new List<GameObject>();
    protected override void Action()
    {
  foreach(GameObject e in enemie)
        {
            e.GetComponent<LifeController>().lifechangers.Add(-dmg);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<DamageToPlayerOnTouch>() == true)
        {
            enemie.Add(collision.gameObject);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<DamageToPlayerOnTouch>() == true)
        {
            enemie.Remove(collision.gameObject);
        }
    }

}
