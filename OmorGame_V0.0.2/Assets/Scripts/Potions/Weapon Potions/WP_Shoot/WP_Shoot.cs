
﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class WP_Shoot  : WeaponPotion
{

    public GameObject pfbBullet;
    public GameObject pfbbulletPointer;

    private GameObject bulletpointer;

    public bool canshoot = true;

    private void OnEnable()
    {
        Initalization();
    }
    public override void Attack(InputAction.CallbackContext contex)
    {
    
       // if (canshoot == false) return;
        GameObject clone;
        clone = Instantiate(pfbBullet,bulletpointer.transform.position,bulletpointer.transform.rotation);
        //clone.GetComponent<Bullet_Fly>().direction = Vector2.up;
        //clone.GetComponent<Bullet_Fly>().direction = contex.action.ReadValue<Vector2>();

        clone.GetComponent<Bullet_Fly>().direction = bulletpointer.transform.position-gameObject.transform.position;
        canshoot = false;
    }
    public override void DetermineDirection(InputAction.CallbackContext contex)
    {
        if (contex.action.ReadValue<Vector2>() == new Vector2(0, 0)) return;
        bulletpointer.GetComponent<Bulletpointer>().positioncircle = contex.action.ReadValue<Vector2>();



    }

    public override void Initalization()
    {
        
        bulletpointer= Instantiate(pfbbulletPointer);
        bulletpointer.GetComponent<Bulletpointer>().player = player.transform;
        Debug.Log("i write player");
    
    }

}
