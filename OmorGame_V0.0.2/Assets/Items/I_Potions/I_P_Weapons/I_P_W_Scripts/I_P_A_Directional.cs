using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class I_P_A_Directional : I_P_Attack
{
    public Vector3 direction;
    public GameObject prefabBullet;
    protected    GameObject clone;
  
    protected override void Action()
    {
     
        clone = Instantiate(prefabBullet, gameObject.transform.position, gameObject.transform.rotation);
        clone.GetComponent<I_P_W_Bullet>().dmg = dmg;
        clone.GetComponent<I_P_W_Bullet>().direction = direction;
        clone.GetComponent<I_P_W_Bullet>().timeUsedToCalculateSpeed = timeUsedToCalculateSpeed;
        clone.GetComponent<I_P_W_Bullet>().isFlying = true;


    }

    private void Update()
    {
        Debug.DrawRay(transform.position, direction*4,Color.green);
    }
}
