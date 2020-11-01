using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageToPlayerOnTouch : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.gameObject.GetComponent<Player>())
        {
            collision.collider.gameObject.GetComponent<LifeController>().lifechangers.Add(-3);
        }
    }





}
