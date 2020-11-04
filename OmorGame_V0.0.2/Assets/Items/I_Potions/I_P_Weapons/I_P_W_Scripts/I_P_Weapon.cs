using System;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;

public class I_P_Weapon : Potion
{
    public GameObject player;

    public GameObject prefabDirectionalAttack;
    public GameObject prefabMeelelAttack;
    public GameObject prefabDodgeAttack;



    public bool canshoot = true;

    private void Awake()
    {

    
    }

    private void Start()
    {

    }

    private void FixedUpdate()
    {

               
    }

    public float Timecheck(float localtime)
    {
        if (localtime <= 0)
        {
            return 0;
        }
        localtime = localtime - Time.fixedDeltaTime;
        return localtime;
    }

    public void DirectionalAttackTimed(InputAction.CallbackContext context)
    {
       
    }
    public void DetermineDirectionTimed(InputAction.CallbackContext context)
    {
        DetermineDirection(context);
    }
    public void MeleeAttackTimed(InputAction.CallbackContext context)
    {

    }




    protected virtual void DirectionelAttack(InputAction.CallbackContext contex)
    {

    }

    protected virtual void DetermineDirection(InputAction.CallbackContext contex)
    {
  

    }

    protected virtual void MeleeAttack(InputAction.CallbackContext contex)
    {

    }

    protected virtual void Initalization()
    {

    }
}
