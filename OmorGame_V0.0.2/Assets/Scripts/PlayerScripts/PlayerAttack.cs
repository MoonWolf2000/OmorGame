﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAttack : MonoBehaviour
{
    public GameObject pfb_WeaponPotion;
    GameObject go_active_WeaponPotion;
    I_P_W_Standart sc_active_WeaponPotion;


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
        sc_active_WeaponPotion = go_active_WeaponPotion.GetComponent<I_P_W_Standart>();
        sc_active_WeaponPotion.player = this.gameObject;
    }
    public void MeeleAttack(InputAction.CallbackContext context)
    {
        sc_active_WeaponPotion.MeleeAttackTimed(context);
    }
    public void DirektionalAttack(InputAction.CallbackContext context)
    {

     
        sc_active_WeaponPotion.DirectionalAttackTimed(context);  
    }

    public void DetermineDirection(InputAction.CallbackContext context)
    {
        sc_active_WeaponPotion.DetermineDirectionTimed(context);
    }

}
