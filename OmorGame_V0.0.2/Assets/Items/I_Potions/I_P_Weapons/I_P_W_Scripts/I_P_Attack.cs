using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public abstract class I_P_Attack : MonoBehaviour
{
    public string displayName;
    [InspectorName("Damage")]
    public float dmg;
    public float cooldown;
    [Space]
    public float timeForMovement;
    public float range;
    [Header("just for debug purpose Speed:")]
    [SerializeField] public float speed;
    [Space]


    private float t1;
  //public float t1;
    public void Attack()
    {
        if (t1 <= 0)
        {
            t1 = cooldown;
            Action();
        }
    }

    protected virtual void Action()
    {

    }

    protected virtual void FixedUpdate()
    {
        speed = range / timeForMovement;
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
