﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Collectable_", menuName = "ScriptableObjects/Collectable", order = 2)]
public class Collectable : ScriptableObject
{ 
    public string ID { get; set; }
    public string Name { get; set; }
    public int Value { get; set; }
}
