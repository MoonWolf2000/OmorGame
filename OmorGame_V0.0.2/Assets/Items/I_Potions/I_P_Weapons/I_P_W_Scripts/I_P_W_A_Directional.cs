using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class I_P_W_A_Directional : I_P_W_Attack
{
    public Vector3 direction;
    public float speed;
    public GameObject prefabBullet;

    protected override void Action()
    {
        GameObject clone;
        clone = Instantiate(prefabBullet, gameObject.transform.position, gameObject.transform.rotation);
        clone.GetComponent<I_P_W_Bullet>().dmg = dmg;
        clone.GetComponent<I_P_W_Bullet>().direction = direction;
    }
}
