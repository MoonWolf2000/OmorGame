using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class BombThrow : I_P_A_Directional
{

    private void Update()
    {
     
        transform.position = new Vector2(transform.parent.position.x, transform.parent.position.y) + direction * prefabBullet.GetComponent<I_P_W_Bullet>().range;
    }


    protected override void Action()
    {

        clone = Instantiate(prefabBullet,transform.parent.transform.position,transform.parent.transform.rotation);
        clone.GetComponent<I_P_W_Bullet>().direction = direction;
        clone.GetComponent<I_P_W_Bullet>().speed = speed;
        clone.GetComponent<I_P_W_Bullet>().timeUsedToCalculateSpeed = timeUsedToCalculateSpeed;
        clone.GetComponent<I_P_W_Bullet>().isFlying = true;
    }
}
