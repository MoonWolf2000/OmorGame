using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeController : MonoBehaviour
{
    public int lifepoints = 15;
    public List<int> lifechangers = new List<int>();
    // Update is called once per frame
    void FixedUpdate()
    {
       

        if (lifechangers.Count == 0) return;
        foreach(int i in lifechangers)
        {
            lifepoints = lifepoints + i;

        }

        lifechangers.Clear();
    }
}
