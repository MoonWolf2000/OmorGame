using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAttack : MonoBehaviour
{
    WeaponPotion wp;

    private void Update()
    {
        wp = GetComponentInChildren<WeaponPotion>();
        Debug.Log(wp.name);
    }
    public void Attack(InputAction.CallbackContext contex)
    {
        if (contex.performed)
        {
            wp.Attack(contex);

        }


    }

    public virtual void DetermineDirection(InputAction.CallbackContext contex)
    {
        if (contex.performed)
        {
        wp.DetermineDirection(contex);

        }
    }

}
