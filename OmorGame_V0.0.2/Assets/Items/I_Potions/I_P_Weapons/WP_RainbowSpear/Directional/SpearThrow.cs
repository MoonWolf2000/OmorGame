using Sirenix.OdinInspector;
using UnityEngine;

public sealed class SpearThrow : I_P_A_Directional
{

    public float spearSpawnTime;
    private float _sst;
private bool _canrespawn = false;
    private void Start()
    {
        _needsBullet = false;
        clone = GetComponent<I_P_Weapon>().GameObjectMA;
        Debug.Log(clone.name);

    }


    [Button]
    protected override void Action()
    {
        if (clone == null) return; 
        direction.LimitDirectionToNWES();
        _canrespawn = true;
        RefillTemptime();
        Debug.Log(_canrespawn);
        clone.transform.parent = null;
        LetFly();
    }

    protected override void FixedUpdateOperations()
    {


        transform.AssignOrientation(direction);
        SpearRespawn();
    }


    private void SpearRespawn()
    {
     //   Debug.LogError(_sst.ToZeroTimer());
            Debug.Log("dshgjfshjgdhjgdhjfgdfhjsjretertuiierretwheoirtuhoithekjwhtqieprpqotgfdsjgdoighfh");
        if (_sst.ToZeroTimer() && _canrespawn)
        {
            Debug.Log(" I respawned the spear");
            gameObject.GetComponent<RainbowSpearPotion>().ReplaceSpear();
            clone = GetComponent<I_P_Weapon>().GameObjectMA;
            _canrespawn = false;
            RefillTemptime();
        }
    }



    private void RefillTemptime()
    {
        _sst = spearSpawnTime;
    }



}
