﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class SpearThrow : I_P_A_Directional
{
    protected override void FixedUpdateOperations()
    {
        if(clone == null)
        {
            BulletInstantiation();
            clone.transform.parent = transform;
         
        }
        
        
    }



    protected override void Action()
    {
        clone.transform.parent = null;
        LetFly();
    }



}
