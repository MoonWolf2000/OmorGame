using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public abstract class I_P_Attack : MonoBehaviour
{
    public string displayName;
    [InspectorName("Damage")]
    public float dmg;
    [Space]
    public float time;
    public float range;
    [Header("just for debug purpose Speed:")]
    [SerializeField] protected float speed;
    [Space]


    private float t1;
  //public float t1;
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

    protected virtual void FixedUpdate()
    {
        speed = range / time;
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
