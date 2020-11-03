using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : ScriptableObject
{ 
    public string ID { get; set; }
    public string Name { get; set; }
    public int Value { get; set; }
}
