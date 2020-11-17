using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class RainbowSpearPotion : I_P_Weapon
{
    public List<Element> sortedElementList = new List<Element> {

    Element.elementA
    };

    private int _elementIndex = 0;
    public void ReplaceSpear()
    {
        GameObjectMA = Instantiate(prefabMeelelAttack, transform.position,transform.rotation) ;
        GameObjectMA.transform.parent = gameObject.transform;
    }

}
