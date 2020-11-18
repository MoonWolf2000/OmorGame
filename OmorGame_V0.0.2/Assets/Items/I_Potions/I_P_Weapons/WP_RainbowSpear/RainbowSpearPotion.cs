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
        Debug.Log(" Icreate a new Spear");
        GameObjectMA = Instantiate(prefabMeelelAttack, transform) ;
        GameObjectMA.transform.parent = gameObject.transform;
    }

}
