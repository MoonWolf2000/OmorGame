using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class BombThrow : I_P_A_Directional
{

    private void Update()
    {
     
        transform.position = transform.parent.position + direction * range;
    }


    protected override void Action()
    {

        clone = Instantiate(prefabBullet,transform.parent.transform.position,transform.parent.transform.rotation);
        clone.GetComponent<I_P_W_Bullet>().dmg = dmg;
        clone.GetComponent<I_P_W_Bullet>().speed = speed;
        clone.GetComponent<I_P_W_Bullet>().direction = direction;
        clone.GetComponent<Bomb>().isFlying = true;
    }
}
