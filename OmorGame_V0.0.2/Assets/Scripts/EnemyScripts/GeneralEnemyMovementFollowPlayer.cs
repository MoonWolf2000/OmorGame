using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneralEnemyMovementFollowPlayer : MonoBehaviour
{
    public GameObject GO_Player;
    public float speed = 2f;
    Rigidbody2D this_rigidbody2D;
    public void Awake()
    {
        this_rigidbody2D = gameObject.GetComponent<Rigidbody2D>();
        GO_Player = FindObjectOfType<Player>().gameObject;
    }

 
    private void FixedUpdate()
    {

        this_rigidbody2D.MovePosition(this_rigidbody2D.position + (new Vector2(GO_Player.transform.position.x, GO_Player.transform.position.y)).normalized * speed * Time.fixedDeltaTime);
    }

}
