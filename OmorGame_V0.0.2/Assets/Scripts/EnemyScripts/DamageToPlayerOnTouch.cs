using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageToPlayerOnTouch : MonoBehaviour
{
    GeneralEnemyMovementFollowPlayer followPlayer;

    private void Awake()
    {
        followPlayer = gameObject.GetComponent<GeneralEnemyMovementFollowPlayer>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Player>())
        {
            collision.gameObject.GetComponent<LifeController>().lifechangers.Add(-3);
            followPlayer.moving = false;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        followPlayer.moving = true;
    }



}
