using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAttack : MonoBehaviour
{
    public WeaponPotion wp;
    public void Attack(InputAction.CallbackContext contex)
    {
        wp.Attack(contex);
    }



}
