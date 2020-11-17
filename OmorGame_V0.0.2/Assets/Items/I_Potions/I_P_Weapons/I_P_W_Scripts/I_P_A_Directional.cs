using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

public class I_P_A_Directional : I_P_Attack
{
    [PropertyOrder(1f)]
    public Vector3 direction;
    protected static bool _needsBullet = true;
    [PropertyOrder(2f)]
    [ShowIf(nameof(_needsBullet))]
    public GameObject prefabBullet;
    protected GameObject clone;
    private int _inversionNumber = 1;

    [PropertyOrder(1.5f)]
    [InlineButton(nameof(SwitchInversion),"Change Inversion")]
    public bool inversed = false;


    protected override void Action()
    {
        BulletInstantiation();
        LetFly();
        
    }

    protected void LetFly()
    {
        clone.GetComponent<I_P_W_Bullet>().direction = direction * _inversionNumber;
        clone.GetComponent<I_P_W_Bullet>().dmg = dmg;
        clone.GetComponent<I_P_W_Bullet>().timeUsedToCalculateSpeed = timeUsedToCalculateSpeed;
        clone.GetComponent<I_P_W_Bullet>().isFlying = true;
    }

    protected  void BulletInstantiation()
    {
        clone = Instantiate(prefabBullet, gameObject.transform.position, gameObject.transform.rotation);
      
    }

    private void Update()
    {
        Debug.DrawRay(transform.position, direction * 4, Color.green);
    }
    private void SwitchInversion()
    {
        inversed = !inversed;
        _inversionNumber = -_inversionNumber;
    }


}
