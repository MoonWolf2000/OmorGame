using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class Shoot : MonoBehaviour
{

    public GameObject pfbBullet;
    public GameObject bulletpointer;
    public bool canshoot = true;

    public void Shooting(InputAction.CallbackContext contex)
    {
    
       // if (canshoot == false) return;
        GameObject clone;
        clone = Instantiate(pfbBullet,bulletpointer.transform.position,bulletpointer.transform.rotation);
        //clone.GetComponent<Bullet_Fly>().direction = Vector2.up;
        //clone.GetComponent<Bullet_Fly>().direction = contex.action.ReadValue<Vector2>();

        clone.GetComponent<Bullet_Fly>().direction = bulletpointer.transform.position-gameObject.transform.position;
        canshoot = false;
    }


}
