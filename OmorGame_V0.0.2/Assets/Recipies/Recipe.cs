using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Recipe_", menuName = "ScriptableObjects/Recipe", order =3 )]
public class Recipe : ScriptableObject
{
    public Collectable[] ingreediens;
}
