using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class LifeDebugger : MonoBehaviour
{

    public LifeController lifeController;

    public void DoDamage(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
           // Debug.Log("The magic lords have decided it is time to take a damage");
             lifeController.lifechangers.Add(-1);

        }
    }
    public void DoHeal(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
         //   Debug.Log("The magic lords have decided you shall be healed");
            lifeController.lifechangers.Add(+2);

        }
    }
}
