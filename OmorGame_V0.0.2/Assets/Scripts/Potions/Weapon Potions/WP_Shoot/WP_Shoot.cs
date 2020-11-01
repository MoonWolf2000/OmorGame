using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class WP_Shoot : WeaponPotion
{

    public GameObject pfbBullet;
    public GameObject pfbbulletPointer;

    private GameObject bulletpointer;
    private Vector3 bulletpointerModifikator;

    public bool canshoot = true;

    private void Awake()
    {
        Initalization();
        dmg = 5f;
        bulletpointerModifikator = new Vector3(1, 1, 0);
    }

    private void FixedUpdate()
    {
        bulletpointer.GetComponent<Rigidbody2D>().MovePosition(gameObject.transform.position + bulletpointerModifikator);
    }


    private void OnEnable()
    {
    }
    public override void Attack(InputAction.CallbackContext contex)
    {

        // if (canshoot == false) return;
        GameObject clone;
        clone = Instantiate(pfbBullet, bulletpointer.transform.position, bulletpointer.transform.rotation);
        //clone.GetComponent<Bullet_Fly>().direction = Vector2.up;
        //clone.GetComponent<Bullet_Fly>().direction = contex.action.ReadValue<Vector2>();

        clone.GetComponent<Bullet_Fly>().direction = bulletpointer.transform.position - gameObject.transform.position;
        clone.GetComponent<Bullet_Fly>().Bullet_dmg = Convert.ToInt32(dmg);
        canshoot = false;
    }
    public override void DetermineDirection(InputAction.CallbackContext contex)
    {
        if (contex.action.ReadValue<Vector2>() == new Vector2(0, 0)) return;
         bulletpointerModifikator = contex.action.ReadValue<Vector2>();



    }

    public override void Initalization()
    {

        bulletpointer = Instantiate(pfbbulletPointer);
       // bulletpointer.GetComponent<Bulletpointer>().player = player.transform;
        Debug.Log("i write player");

    }

}
