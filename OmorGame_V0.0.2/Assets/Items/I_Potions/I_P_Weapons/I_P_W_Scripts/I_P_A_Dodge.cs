﻿using UnityEngine;

public class I_P_A_Dodge : I_P_Attack
{
    [Header("TIME SETTINGS (time in seconds)")]
    [Space]
    public float duration;
    [Header("Smaller number means later!")]
    public float startIndestructability;
    public float endIndestructability;
    private MoveController playerMoveController;
    private GameObject player;
    private Rigidbody2D playerRigidbody2D;
    private LifeController playerLifeController;

    private bool isDodging;
    //private Vector2 startposition;
    private Vector2 direction;
    private float d;
    
    private void Awake()
    {
        player = FindObjectOfType<Player>().gameObject;
        playerMoveController = player.GetComponent<MoveController>();
        playerRigidbody2D = player.GetComponent<Rigidbody2D>();
        playerLifeController = player.GetComponent<LifeController>();
    }

    protected override void Action()
    {
        playerMoveController.moving = false;
        direction = playerMoveController.directions[playerMoveController.futureDirection];
        playerLifeController.damageable = false;
        d = duration;
        isDodging = true;
    }


    protected override void FixedUpdate()
    {
        base.FixedUpdate();
        if (!isDodging) return;
       if(d< startIndestructability && d > endIndestructability)
        {
            playerLifeController.damageable = false;
        }
       if(d< endIndestructability)
        {
            playerLifeController.damageable = true;
        }
        d = d - Time.fixedDeltaTime;
        playerRigidbody2D.MovePosition(playerRigidbody2D.position + direction * speed * Time.fixedDeltaTime);
        if (d <= 0)
        {
            isDodging = false;
            playerLifeController.damageable = true;
            playerMoveController.moving = true;
        }
    }

}
