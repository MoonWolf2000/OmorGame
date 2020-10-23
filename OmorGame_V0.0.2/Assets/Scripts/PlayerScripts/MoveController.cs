using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MoveController : MonoBehaviour
{
   public Vector2 movement;
    public float speed = 5f ;
    public Rigidbody2D rb;
   public  bool moving = true;

    private void FixedUpdate()
    {
        if (moving = false) return; 
        rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);

    }

    public void Moving(InputAction.CallbackContext context)
    {
        movement = context.action.ReadValue<Vector2>();
    
    }

}
