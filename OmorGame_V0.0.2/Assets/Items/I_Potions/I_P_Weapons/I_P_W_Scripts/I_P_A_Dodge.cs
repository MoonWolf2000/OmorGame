using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class I_P_A_Dodge : I_P_Attack
{
    private  MoveController playerMoveController;
    private GameObject player;
    private Rigidbody2D playerRigidbody2D;
    private bool isDodging;
    public float speed;
    private Vector3 startposition;

    private void Awake()
    {
        player = FindObjectOfType<Player>().gameObject;
        playerMoveController =player.GetComponent<MoveController>();
        playerRigidbody2D = player.GetComponent<Rigidbody2D>();
    }

    protected override void Action()
    {
        playerMoveController.moving = false;
        startposition = player.transform.position;
        isDodging = true;
    }

    private void FixedUpdate()
    {
        if (!isDodging) return;
 
        playerRigidbody2D.MovePosition(playerRigidbody2D.position + Vector2.up * speed * Time.fixedDeltaTime);
        if (player.transform.position == startposition + Vector3.forward*range)
        {
            Debug.Log(" i dodged");
            isDodging = false;
            playerMoveController.moving = true;
        }
    }

}
