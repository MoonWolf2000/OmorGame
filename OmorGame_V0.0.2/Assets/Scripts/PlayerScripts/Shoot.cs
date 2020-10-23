using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class Shoot : MonoBehaviour
{

    public GameObject pfbBullet;
    public bool canshoot = true;

    public void Shooting(InputAction.CallbackContext contex)
    {
        if (contex.action.ReadValue<Vector2>() == new Vector2(0, 0)) return;
       // if (canshoot == false) return;
        GameObject clone;
        clone = Instantiate(pfbBullet,transform.position,transform.rotation);
        clone.GetComponent<Bullet_Fly>().direction = contex.action.ReadValue<Vector2>();
        canshoot = false;
    }
}
