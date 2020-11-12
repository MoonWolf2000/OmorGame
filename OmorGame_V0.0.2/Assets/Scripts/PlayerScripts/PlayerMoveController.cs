
﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMoveController : MonoBehaviour
{
   public Vector2 movement;
    public float speed = 5f ;
    public Rigidbody2D rb;
    public bool moving = true;
    public Transform t;
  public  int futureDirection = 0;

    public  Vector2[] directions = new Vector2[4];

    private void FixedUpdate()
    {
        if (moving == false) return;
        rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);

    }

    public void Moving(InputAction.CallbackContext context)
    {
        movement = context.action.ReadValue<Vector2>();

        OrientatioCheck(context.action.ReadValue<Vector2>());
    }


   private void OrientatioCheck(Vector2 input)
    {
        if (input == new Vector2(0, 0)) return;
        int i = 0;

        float min= 2;
        foreach(Vector2 v in directions)
        {
          
            if((input-v).magnitude <= min)
            {
                min = (input - v).magnitude;
                futureDirection = i;
            }
            i++;
        }
 
        //Debug.LogError("StOOOP");
        switch(futureDirection)
        {
            case 0:
          
                t.rotation = Quaternion.Euler(0f, 0f, 0f);
                break;
            case 1:
                t.rotation = Quaternion.Euler(0f, 0f, 180f);
                break;
            case 2:
                t.rotation = Quaternion.Euler(0f, 0f, 270f);
                break;
            case 3:
                t.rotation = Quaternion.Euler(0f, 0f, 90f);
                break;


                //default:
                //    t.rotation = new Quaternion(0f, 0f, -270f, 0f);
                //    break;

        }


    }

}

