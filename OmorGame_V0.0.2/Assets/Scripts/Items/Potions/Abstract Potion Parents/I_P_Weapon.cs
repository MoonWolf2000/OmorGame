using UnityEngine;
using UnityEngine.InputSystem;

public class I_P_Weapon : Potion
{
    public GameObject player;

    public GameObject prefabDirectionalAttack;
    public GameObject prefabMeelelAttack;
    public GameObject prefabDodgeAttack;

    [HideInInspector]
    public GameObject GameObjectMA
    {
        protected set;
        get;
    }
    public GameObject GameObjectDoA

    {
        protected set;
        get;
    }

    public GameObject GameObjectDA
    {
        protected set;
        get;
    }

    private I_P_A_Directional directionalAttack;
    private I_P_A_Melee meelelAttack;
    private I_P_A_Dodge dodgeAttack;



    public bool canshoot = true;

    protected virtual void Awake()
    {
        Initalization();
    }

    private void Start()
    {
    }



    public void DirectionalAttackTimed(InputAction.CallbackContext context)
    {

        if (context.canceled && context.duration >= directionalAttack.chargetime)
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
        GameObjectDA = PrefabCheck(prefabDirectionalAttack);
        GameObjectMA = PrefabCheck(prefabMeelelAttack);
        GameObjectDoA = PrefabCheck(prefabDodgeAttack);
        directionalAttack = GameObjectDA.GetComponent<I_P_A_Directional>();
        meelelAttack = GameObjectMA.GetComponent<I_P_A_Melee>();
        dodgeAttack = GameObjectDoA.GetComponent<I_P_A_Dodge>();
    }
    /// <summary>
    /// counts doen time untill its zero should to be in fixdeupdate ;
    /// </summary>
    /// <param name="temptime"></param>
    /// <returns></returns>

}
