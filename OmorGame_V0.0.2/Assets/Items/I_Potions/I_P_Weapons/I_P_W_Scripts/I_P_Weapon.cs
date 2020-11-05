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
    private I_P_A_Directional directionalAttack;
    private I_P_A_Melee meelelAttack;
  //  private I_P_W_A_Dodge dodgeAttack;



    public bool canshoot = true;

    private void Awake()
    {
        directionalAttack = prefabDirectionalAttack.GetComponent<I_P_A_Directional>();
        meelelAttack = prefabMeelelAttack.GetComponent<I_P_A_Melee>();
       // dodgeAttack = prefabDodgeAttack.GetComponent<I_P_W_A_Dodge>();

    
    }

    private void Start()
    {
      //  Instantiate(prefabMeelelAttack, this.gameObject.transform.position, this.gameObject.transform.rotation);
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
        if (context.performed)
        directionalAttack.Attack();
    }
    public void DetermineDirectionTimed(InputAction.CallbackContext context)
    {

        directionalAttack.direction = context.action.ReadValue<Vector2>();
    }
    public void MeleeAttackTimed(InputAction.CallbackContext context)
    {
        if (context.performed)
        meelelAttack.Attack();
    }

    //public void DodgeAttack(InputAction.CallbackContext context)
    //{
    //    if (context.performed)
    //        dodgeAttack.Attack();
    //}



    protected virtual void Initalization()
    {

    }
}
