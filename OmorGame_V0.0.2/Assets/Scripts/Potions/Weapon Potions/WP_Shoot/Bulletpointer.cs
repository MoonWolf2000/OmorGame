using UnityEngine;
using UnityEngine.InputSystem;

public class Bulletpointer : MonoBehaviour
{
    public Vector2 positioncircle;
    public Transform player;

    private void Start()
    {

        positioncircle =   new Vector2(1, 0);
       
    }
    private void FixedUpdate()
    {
        if (player == null) return;
        transform.position = new Vector2(player.transform.position.x, player.transform.position.y) + positioncircle;
    }

}
