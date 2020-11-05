using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class I_P_Attack : MonoBehaviour
{
    public string displayName;

    public float time;
    public float dmg;
    public float range;
    public Vector3 weaponPosition;



     
    private float t1;
    public void Attack()
    {
        if (t1 <= 0)
        {
            t1 = time;
            Action();
        }
    }

    protected virtual void Action()
    {

    }

    private void FixedUpdate()
    {
        t1 = Timecheck(t1);        
    }

    private static float Timecheck(float localtime)
    {
        if (localtime <= 0)
        {
            return 0;
        }
        localtime = localtime - Time.fixedDeltaTime;
        return localtime;
    }

   

}
