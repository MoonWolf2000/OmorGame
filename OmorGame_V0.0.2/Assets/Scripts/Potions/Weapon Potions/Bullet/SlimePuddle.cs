using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimePuddle : I_P_Attack
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        EnemyStatusChanger(collision.gameObject, EnemyStatusController.EnenemyStatus.c);
    }



}
