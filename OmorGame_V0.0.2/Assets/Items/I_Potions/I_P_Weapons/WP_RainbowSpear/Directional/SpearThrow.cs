using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

public sealed class SpearThrow : I_P_A_Directional
{

    private void Start()
    {
        _needsBullet = false;
        clone = GetComponent<I_P_Weapon>().GameObjectMA;
        Debug.Log(clone.name);
    }

    
    [Button]
    protected override void Action()
    {
        clone = GetComponent<I_P_Weapon>().GameObjectMA;
        
        Debug.Log("sdfogdfgjkjkskjdfszkekjsepo"+ clone.name);
        LetFly();
    }

    protected override void FixedUpdateOperations()
    {
 
        if(clone = null)
        clone = GetComponent<I_P_Weapon>().GameObjectMA;

    }




}
