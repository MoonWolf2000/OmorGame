using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class I_P_A_Melee : I_P_Attack
{
    public List<GameObject> enemie = new List<GameObject>();

    protected override void Action()
    {
        base.Action();
        Debug.Log("test");
        foreach (GameObject e in enemie)
        {
            e.GetComponent<LifeController>().lifechangers.Add(-dmg);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<DamageToPlayerOnTouch>() == true)
        {
            enemie.Add(collision.gameObject);
            collision.gameObject.GetComponent<LifeController>().lifechangers.Add(-dmg);
            Debug.Log("jsdjdfjh");
            Debug.Log(time);
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
