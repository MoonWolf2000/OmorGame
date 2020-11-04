using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class I_P_W_Attack : MonoBehaviour
{
    public string displayName;

    public float time;
    public float dmg;
    public float range;
    public Vector3 weaponPosition;


    public virtual void Action()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<DamageToPlayerOnTouch>() == true)
        {
            collision.gameObject.GetComponent<LifeController>().lifechangers.Add(-dmg);
            Destroy(gameObject);

        }
    }


}
