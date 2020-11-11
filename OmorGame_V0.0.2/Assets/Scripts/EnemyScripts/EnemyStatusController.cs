using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStatusController : MonoBehaviour
{
    public EnenemyStatus status;
    
    public void StatusDoStuffer()
    {
        switch (status)
        {
            case EnenemyStatus.a:
                break;
            case EnenemyStatus.b:
                break;
            case EnenemyStatus.c:
                break;
            case EnenemyStatus.d:
                break;
            case EnenemyStatus.e:
                break;

        }
    }


    public enum EnenemyStatus
    {
        a= 0,
        b= 1,
        c= 2,
        d= 3,
        e= 4 ,
    }
}
