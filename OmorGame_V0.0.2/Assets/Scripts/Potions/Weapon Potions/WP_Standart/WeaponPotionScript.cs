using System;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;

public class WeaponPotion : Potion
{
    public GameObject player;
    public float dmg;
    public float distance;
    public float directionAttackTime;
    public float meleeAttackTime;

    private GameObject pfbBullet;
    private GameObject pfbbulletPointer;
    private GameObject bulletpointer;
    private Vector3 bulletpointerModifikator;
    private float t1 =0;
    private float t2 =0;


    public bool canshoot = true;

    private void Awake()
    {

        pfbBullet = AssetDatabase.LoadAssetAtPath("Assets/Prefabs/Potions/Weapon Potions/Standart Prefabs (DoNotMove)/Bullet.prefab", typeof(GameObject)) as GameObject;
        pfbbulletPointer = AssetDatabase.LoadAssetAtPath("Assets/Prefabs/Potions/Weapon Potions/Standart Prefabs (DoNotMove)/Bulletpiont.prefab", typeof(GameObject)) as GameObject;
        Initalization();
        bulletpointerModifikator = new Vector3(1, 1, 0);
    }

    private void Start()
    {

    }

    private void FixedUpdate()
    {
        bulletpointer.GetComponent<Rigidbody2D>().MovePosition(gameObject.transform.position + bulletpointerModifikator);
    }

    public void DirectionalAttackTimed(InputAction.CallbackContext contex)
    {
        if (TimeCheck(t1, directionAttackTime))
        {
            DirectionelAttack(contex);
        }
    }
    public void DetermineDirectionTimed(InputAction.CallbackContext contex)
    {
        DetermineDirection(contex);
    }
    public void MeleeAttackTimed(InputAction.CallbackContext contex)
    {
        if(TimeCheck(t2,meleeAttackTime))
        {
            MeleeAttack(contex);
        }
    }


    private bool TimeCheck(float localtime, float worldtime)
    {
        localtime = localtime - Time.fixedDeltaTime;
        if (localtime <= 0)
        {
            localtime = worldtime;
            return true;
        }

        return false;
    }


    protected virtual void DirectionelAttack(InputAction.CallbackContext contex)
    {
        GameObject clone;
        clone = Instantiate(pfbBullet, bulletpointer.transform.position, bulletpointer.transform.rotation);
        clone.GetComponent<Bullet_Fly>().direction = bulletpointer.transform.position - gameObject.transform.position;
        clone.GetComponent<Bullet_Fly>().Bullet_dmg = Convert.ToInt32(dmg);
        canshoot = false;
    }

    protected virtual void DetermineDirection(InputAction.CallbackContext contex)
    {
        if (contex.action.ReadValue<Vector2>() == new Vector2(0, 0)) return;
        bulletpointerModifikator = contex.action.ReadValue<Vector2>();

    }

    protected virtual void MeleeAttack(InputAction.CallbackContext contex)
    {
        Debug.Log(" Meelee Booom");
    }

    protected virtual void Initalization()
    {
        bulletpointer = Instantiate(pfbbulletPointer);
    }
}
