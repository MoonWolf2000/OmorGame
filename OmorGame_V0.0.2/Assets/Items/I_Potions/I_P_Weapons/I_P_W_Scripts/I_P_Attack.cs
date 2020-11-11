using System.Linq;
using UnityEngine;
using System.Collections.Generic;

public abstract class I_P_Attack : MonoBehaviour
{
    public string displayName;
    [InspectorName("Damage")]
    public float chargetime;
    public float dmg;
    public float cooldown;
    [Space]
    [Header("just for debug purpose Speed:")]
    [SerializeField] public float speed;
    [Space]
    public float range;
    [Header("TIME SETTINGS (time in seconds)")]
    public float timeUsedToCalculateSpeed = 1;

    private float _t1;
    //public float t1;
    public void Attack()
    {
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
        speed = range / timeUsedToCalculateSpeed;
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
        speed = range / timeUsedToCalculateSpeed;
        _t1 = Timecheck(_t1);
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
}
