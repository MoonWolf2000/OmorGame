using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class I_P_A_Melee : I_P_Attack
{
    public List<LifeController> enemies = new List<LifeController>();

    protected override void Action()
    {
        DMGtoAll(enemies);
     
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Enemie>())
        {
            enemies.Add(collision.gameObject.GetComponent<LifeController>());
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Enemie>())
        {
            enemies.Remove(collision.gameObject.GetComponent<LifeController>());
        }
    }

}
