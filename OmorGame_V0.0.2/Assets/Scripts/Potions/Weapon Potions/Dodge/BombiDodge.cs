using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class BombiDodge :I_P_A_Dodge
{
    public GameObject prefabBomb;
    private GameObject clone;
    private bool didDodge = false;

    protected override void Action()
    {
        base.Action();
        didDodge = true;
    }
    protected override void FixedUpdateOperations()
    { 
        if (didDodge)
        {
        clone = Instantiate(prefabBomb, gameObject.transform.position, gameObject.transform.rotation);
            clone.GetComponent<I_P_W_Bullet>().WriteValues();
        didDodge = false;
        }
        base.FixedUpdateOperations();

    }
}
