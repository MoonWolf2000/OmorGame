using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Sirenix.OdinInspector;

public class NewPlayerAttack : MonoBehaviour
{
    [AssetList(Path = "/Prefabs/Weapon Potions/Potions")]
    [InlineEditor(InlineEditorModes.LargePreview)]
    public GameObject WeaponPotion;

    GameObject go_active_WeaponPotion;
    I_P_Weapon sc_active_WeaponPotion;


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
        go_active_WeaponPotion = Instantiate(WeaponPotion, gameObject.transform);
        sc_active_WeaponPotion = go_active_WeaponPotion.GetComponent<I_P_Weapon>();
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
    public void DodgeAttack(InputAction.CallbackContext context)
    {
        sc_active_WeaponPotion.DodgeAttack(context);
    }

}
