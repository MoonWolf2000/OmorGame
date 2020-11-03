﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAttack : MonoBehaviour
{
    public GameObject pfb_WeaponPotion;
    GameObject go_active_WeaponPotion;
    WeaponPotion sc_active_WeaponPotion;


    private void Start()
    {
        LoadeWeapon();
    }
    private void Update()
    {
       
    }

    public void LoadeWeapon()
    {
        if (go_active_WeaponPotion != null) 
        {
            Destroy(go_active_WeaponPotion);
        }
        go_active_WeaponPotion = Instantiate(pfb_WeaponPotion, gameObject.transform);
        sc_active_WeaponPotion = go_active_WeaponPotion.GetComponent<WeaponPotion>();
        sc_active_WeaponPotion.player = this.gameObject;
    }
    public void Attack(InputAction.CallbackContext contex)
    {
        if (contex.performed)
        {
            sc_active_WeaponPotion.DirectionelAttack(contex);

        }


    }

    public virtual void DetermineDirection(InputAction.CallbackContext contex)
    {
        if (contex.performed)
        {
        sc_active_WeaponPotion.DetermineDirection(contex);

        }
    }

}
