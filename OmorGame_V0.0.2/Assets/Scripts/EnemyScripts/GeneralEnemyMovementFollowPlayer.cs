using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneralEnemyMovementFollowPlayer : MonoBehaviour
{
    public GameObject GO_Player;
    public float speed = 1f;
    Rigidbody2D this_rigidbody2D;
    Rigidbody2D GO_player_rigidbody2D;
    Vector2 direction;
    Vector2 movement;
   public bool moving;
    
    public void Awake()
    {
        this_rigidbody2D = gameObject.GetComponent<Rigidbody2D>();
        GO_Player = FindObjectOfType<Player>().gameObject;
        GO_player_rigidbody2D = GO_Player.GetComponent<Rigidbody2D>();
        moving = true;
    }

 
    private void FixedUpdate()
    {

        direction = GO_player_rigidbody2D.position- this_rigidbody2D.position;
        direction.Normalize();
        movement = direction;
        Debug.Log(movement);

        if (moving == true )
        {
            this_rigidbody2D.MovePosition(this_rigidbody2D.position+(movement * speed * Time.fixedDeltaTime));
        }
       

    }

}
