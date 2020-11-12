
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.InputSystem;

public class MoveController : MonoBehaviour
{
    public Vector2 movement;
    public float range;
    public float time = 1;
    [Inheritance]
    [SerializeField] private float speed;
    private Rigidbody2D rb;
    public bool moving = true;
    private Transform t;
    [HideInInspector] public int futureDirection = 0;

    [HideInInspector] public Vector2[] directions = new Vector2[4];

    private void Awake()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        t = transform;
    }

    private void FixedUpdate()
    {

        speed = range / time;

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

        float min = 2;
        foreach (Vector2 v in directions)
        {

            if ((input - v).magnitude <= min)
            {
                min = (input - v).magnitude;
                futureDirection = i;
            }
            i++;
        }

        switch (futureDirection)
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

