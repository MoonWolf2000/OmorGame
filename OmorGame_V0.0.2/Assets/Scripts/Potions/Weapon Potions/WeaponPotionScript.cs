using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class WeaponPotion : MonoBehaviour
{
    public GameObject player;
    public float dmg;
    public float distance;
    public float time;

    private void Start()
    {
      
    }

    public virtual void Attack(InputAction.CallbackContext contex)
    {

    }

    public virtual void DetermineDirection(InputAction.CallbackContext contex)
    {

    }

    public virtual  void Initalization()
    {

    }
}
