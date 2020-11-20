using System.Linq;
using UnityEngine;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using Sirenix.Utilities.Editor;
using UnityEditor;

public abstract class I_P_Attack : MonoBehaviour
{
    public string displayName;
    
    [TabGroup("Attack Values")]
    [PropertyOrder(1f),PropertyRange(0f,5f)]
    public float chargetime;
    [TabGroup("Attack Values")]
    [PropertyOrder(1.1f), PropertyRange(0, 50)]
    public float dmg;
    [TabGroup("Attack Values")]
    [PropertyOrder(1.2f), PropertyRange(0f, 5f)]
    public float cooldown;

    [TabGroup("Speed Calculation")]
     public float speed;
    [TabGroup("Speed Calculation")]
    [PropertyRange(1f,15f),OnValueChanged(nameof(CalculateSpeed))]
    public float attackrange = 1f;
    [TabGroup("Speed Calculation")]
    [PropertyRange(1f, 15f)]
    public float attackTime = 1f;
    [TabGroup("Speed Calculation")]
    [InfoBox(nameof(speedCalculationInfo))]



    [TabGroup("Attack Values")]
    [PropertyOrder(1.21f),ReadOnly,ShowInInspector,ProgressBar(0f,nameof(cooldown)),HideLabel]
    private float _t1;
    private string speedCalculationInfo = "Speed is used for : test";

    //public float t1;
    public void Attack()
    {
        speed = attackrange / attackTime;
        if (_t1 <= 0)
        {
            _t1 = cooldown;
            Action();
        }
    }

    protected virtual void Action()
    {

    }

    private void Update()
    {
       
    }

  private void FixedUpdate()
    {

        FixedUpdateStandartOperation();
        FixedUpdateOperations();
    }

    protected virtual void FixedUpdateOperations()
    {

    }

    protected void FixedUpdateStandartOperation()
    {
       
        _t1 = Timecheck(_t1);
    }


    private void CalculateSpeed()
    {
        speed = attackrange / attackTime;
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

    protected void DMGtoAll(List<LifeController> lf)
    {
        lf.Select(l => l.lifechangers).ToList()
            .ForEach(l => l.Add(-dmg));
    }

    protected void DMGtoCollidingOject(Collision collision)
    {
        if (collision.gameObject.GetComponent<Enemie>())
        {
            collision.gameObject.GetComponent<LifeController>().lifechangers.Add(-dmg);
        }
    }

    protected void DMGtoEnemiesinCertainProximity(float distance)
    {
        FindObjectsOfType<LifeController>()
            .Where(l => l.gameObject.GetComponent<Enemie>() == true)
            .Where(l => Vector3.Distance(l.transform.position, transform.position) <= distance)
            .Select(l => l.lifechangers).ToList()
            .ForEach(l => l.Add(-dmg));

    }

    protected void EnemyStatusChanger(GameObject enemieGameobject,EnemyStatusController.EnenemyStatus enenemyStatus)
    {
        if (enemieGameobject.GetComponent<Enemie>())
        {
            enemieGameobject.GetComponent<EnemyStatusController>().status = enenemyStatus;
            Debug.Log("Hier muss noch Statuschanger Code hin  " + enenemyStatus);
        }

    }
    private static float RangeClamp(float value, GUIContent label)
    {
        return EditorGUILayout.Slider(label, value, 0f, 10f);
    }
    private static float TimeClamp(float value, GUIContent label)
    {
        return EditorGUILayout.Slider(label, value, 0f, 1f);
    }
}
