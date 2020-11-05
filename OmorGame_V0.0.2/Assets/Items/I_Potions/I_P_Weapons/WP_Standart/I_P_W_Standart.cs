using System;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;

public class I_P_W_Standart : I_P_Weapon
{
    GameObject i_P_A_M_Standart;

    private void Start()
    {

       i_P_A_M_Standart= Instantiate(prefabMeelelAttack, gameObject.transform);
    }


    private void Update()
    {
        
    }
}
