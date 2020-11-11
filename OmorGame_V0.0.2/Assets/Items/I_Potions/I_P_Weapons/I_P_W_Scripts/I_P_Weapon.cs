using UnityEngine;
using UnityEngine.InputSystem;

public class I_P_Weapon : Potion
{
    public GameObject player;

    public GameObject prefabDirectionalAttack;
    public GameObject prefabMeelelAttack;
    public GameObject prefabDodgeAttack;

    private GameObject gameObjectDA;
    private GameObject gameObjectMA;
    private GameObject gameObjectDoA;

    private I_P_A_Directional directionalAttack;
    private I_P_A_Melee meelelAttack;
    private I_P_A_Dodge dodgeAttack;



    public bool canshoot = true;

    protected virtual void Awake()
    {
    }

    private void Start()
    {
        Initalization();
    }



    public void DirectionalAttackTimed(InputAction.CallbackContext context)
    {
        if (context.canceled && context.duration >=directionalAttack.chargetime )
            directionalAttack.Attack();
    }
    public void DetermineDirectionTimed(InputAction.CallbackContext context)
    {

        directionalAttack.direction = context.action.ReadValue<Vector2>();
    }
    public void MeleeAttackTimed(InputAction.CallbackContext context)
    {
        if (context.canceled && context.duration >= meelelAttack.chargetime)
        {
        Debug.Log("Now i can booooom");
            meelelAttack.Attack();

        }
    }
    public void DodgeAttack(InputAction.CallbackContext context)
    {
        if (context.canceled && context.duration >= dodgeAttack.chargetime)
            dodgeAttack.Attack();
    }



    private GameObject PrefabCheck(GameObject prefab)
    {
        if (prefab != gameObject)
        {
            return Instantiate(prefab, transform);
        }
        else
        {
            return gameObject;
        }

    }

    private void Initalization()
    {
        gameObjectDA = PrefabCheck(prefabDirectionalAttack);
        gameObjectMA = PrefabCheck(prefabMeelelAttack);
        gameObjectDoA = PrefabCheck(prefabDodgeAttack);
        directionalAttack = gameObjectDA.GetComponent<I_P_A_Directional>();
        meelelAttack = gameObjectMA.GetComponent<I_P_A_Melee>();
        dodgeAttack = gameObjectDoA.GetComponent<I_P_A_Dodge>();
    }
}
