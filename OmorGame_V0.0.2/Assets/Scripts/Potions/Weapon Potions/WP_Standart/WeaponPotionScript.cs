using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.InputSystem;
using UnityEditor;

public class WeaponPotion : Potion
{
    public GameObject player;
    public float dmg;
    public float distance;
    public float directionAttackTime;
    public float meleeAttackTime;

    private  GameObject pfbBullet;
    private GameObject pfbbulletPointer;
    private GameObject bulletpointer;
    private Vector3 bulletpointerModifikator;

    public bool canshoot = true;

    private void Awake()
    {

        pfbBullet =  AssetDatabase.LoadAssetAtPath("Assets/Prefabs/Potions/Weapon Potions/Standart Prefabs (DoNotMove)/Bullet.prefab", typeof(GameObject)) as GameObject;
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

    public void DA1(InputAction.CallbackContext contex)
    {
        DirectionelAttack(contex);
    }    
    public void DD1(InputAction.CallbackContext contex)
    {
        DetermineDirection(contex);
    }    
   public void MA1(InputAction.CallbackContext contex)
    {
       MeleeAttack(contex);
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

    }

    protected virtual  void Initalization()
    {
        bulletpointer = Instantiate(pfbbulletPointer);
    }
}
