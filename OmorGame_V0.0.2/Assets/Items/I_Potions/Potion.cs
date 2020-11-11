﻿using UnityEngine;

public class Potion : MonoBehaviour
{
    public string ID;
    public string displayName;
    public Element element;
    public Recipe[] Recipe;
    public virtual void Drink()
    {

    }

    public enum Element
    {
       elementA = 0,
       elementB = 1,
       elementC = 2,
       elementD = 3
    }
}
