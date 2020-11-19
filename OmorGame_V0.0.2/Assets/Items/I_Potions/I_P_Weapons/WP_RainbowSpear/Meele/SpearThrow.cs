using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class SpearThrow : I_P_A_Directional
{
    public List<Element> sortedElementList = new List<Element> {

    Element.elementA
    };

    private int _elementIndex = 0;

    public bool CanStab
    {
        private set;
        get;
    }

    protected override void Action()
    {
        BulletInstantiation();
        clone.GetComponent<SpearAura>().element = sortedElementList[_elementIndex];
        _elementIndex = (_elementIndex == sortedElementList.Count - 1 ? 0: _elementIndex++);
        clone.GetComponent<Rigidbody2D>().RotationToNWES(direction); 
        direction.LimitDirectionToNWES();
        Debug.Log(direction);
        Debug.Log(_elementIndex);
        LetFly();
    }


    protected override void FixedUpdateOperations()
    {
        base.FixedUpdateOperations();

    }
    
}
