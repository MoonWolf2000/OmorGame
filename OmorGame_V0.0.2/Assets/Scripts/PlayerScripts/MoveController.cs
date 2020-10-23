using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MoveController : MonoBehaviour
{
   public Vector2 movement;
    public float speed = 5f ;
    public Rigidbody2D rb;

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);

    }

    public void Moving(InputAction.CallbackContext context)
    {
        Debug.Log("I wanna move ");
        movement = context.action.ReadValue<Vector2>();   

    }

}
