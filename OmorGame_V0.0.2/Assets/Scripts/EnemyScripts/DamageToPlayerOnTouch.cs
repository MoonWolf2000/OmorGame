using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageToPlayerOnTouch : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        collision.collider.gameObject.GetComponent<LifeController>().lifechangers.Add(-3);
    }
}
