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

    private GameObject pfbSword;
    private GameObject Sword;

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
        t1 = Timecheck(t1); 
        t2 = Timecheck(t2); 
               
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
        Debug.Log(context.startTime);
       
        if (t1 <= 0)
        { 
            DirectionelAttack(context);
            t1 = meleeAttackTime;
        }
    }
    public void DetermineDirectionTimed(InputAction.CallbackContext context)
    {
        DetermineDirection(context);
    }
    public void MeleeAttackTimed(InputAction.CallbackContext context)
    {
        if (t2 <= 0)
        {
            MeleeAttack(context);
            t2 = meleeAttackTime;

        }
        
    }




    protected virtual void DirectionelAttack(InputAction.CallbackContext contex)
    {
            Debug.Log(contex.duration);

        if (contex.duration > 0.1)
        {

            GameObject clone;
            clone = Instantiate(pfbBullet, gameObject.transform.position, gameObject.transform.rotation);
            clone.GetComponent<Bullet_Fly>().direction = bulletpointerModifikator;
            //clone.GetComponent<Bullet_Fly>().direction = bulletpointer.transform.position - gameObject.transform.position;
            clone.GetComponent<Bullet_Fly>().Bullet_dmg = Convert.ToInt32(dmg);
            canshoot = false;
        }
    }

    protected virtual void DetermineDirection(InputAction.CallbackContext contex)
    {
        if (contex.action.ReadValue<Vector2>() == new Vector2(0, 0)) return;
        bulletpointerModifikator = contex.action.ReadValue<Vector2>();

    }

    protected virtual void MeleeAttack(InputAction.CallbackContext contex)
    {

        GameObject Sword;
        Sword = Instantiate(pfbSword, player.transform.position, player.transform.rotation);
       

    }

    protected virtual void Initalization()
    {
        bulletpointer = Instantiate(pfbbulletPointer);
       

    }
}
