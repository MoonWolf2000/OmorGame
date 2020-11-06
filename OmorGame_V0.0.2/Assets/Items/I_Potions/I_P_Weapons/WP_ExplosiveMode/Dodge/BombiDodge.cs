using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class BombiDodge :I_P_A_Dodge
{
    public GameObject prefabBomb;
    private GameObject clone;

    protected override void FixedUpdate()
    {
        clone = Instantiate(prefabBomb, gameObject.transform.position, gameObject.transform.rotation);
        clone.GetComponent<Bomb>().Explode();
        base.FixedUpdate();

    }
}
