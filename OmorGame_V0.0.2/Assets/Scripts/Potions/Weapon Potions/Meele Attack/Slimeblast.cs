using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public sealed class Slimeblast : I_P_A_Melee
{
    public float bigDMG;

    protected override void Action()
    {
        //enemies.Where(e => e.GetComponent<EnemyStatusController>().status == EnemyStatusController.EnenemyStatus.b).Select(e => e.GetComponent<LifeController>()).ToList().ForEach(l => l.lifechangers.Add(bigDMG));
        enemies.Where(e => e.gameObject.GetComponent<EnemyStatusController>().status == EnemyStatusController.EnenemyStatus.b).Select(e => e.GetComponent<LifeController>()).ToList().ForEach(l => l.lifechangers.Add(-bigDMG));
        enemies.Where(e => e.gameObject.GetComponent<EnemyStatusController>().status != EnemyStatusController.EnenemyStatus.b).Select(e => e.GetComponent<LifeController>()).ToList().ForEach(l => l.lifechangers.Add(-dmg));
        //enemies.GroupBy(e => e.gameObject.GetComponent<EnemyStatusController>().status).;
    }
}
