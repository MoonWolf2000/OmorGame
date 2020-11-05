using UnityEngine;

public class I_P_A_Dodge : I_P_Attack
{
    public float duration;

    private MoveController playerMoveController;
    private GameObject player;
    private Rigidbody2D playerRigidbody2D;
    private bool isDodging;
    private float speed;
    private Vector2 startposition;
    private Vector2 direction;
    private float d;
    private void Awake()
    {
        player = FindObjectOfType<Player>().gameObject;
        playerMoveController = player.GetComponent<MoveController>();
        playerRigidbody2D = player.GetComponent<Rigidbody2D>();
    }

    protected override void Action()
    {
        playerMoveController.moving = false;
        direction = playerMoveController.directions[playerMoveController.futureDirection];
        d = duration;
        speed =  range/duration;
        isDodging = true;
    }


    protected override void FixedUpdate()
    {
        base.FixedUpdate();
        if (!isDodging) return;
        d = d - Time.fixedDeltaTime;
        playerRigidbody2D.MovePosition(playerRigidbody2D.position + direction * speed * Time.fixedDeltaTime);
        if (d <= 0)
        {
            isDodging = false;
            playerMoveController.moving = true;
        }
    }

}
