using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
public class LifeController : MonoBehaviour
{
    [ProgressBar(0,50)]
    public float lifepoints = 15;
    [ReadOnly]
    public bool damageable = true;
    public List<float> lifechangers = new List<float>();
    // Update is called once per frame
    void FixedUpdate()
    {
       

        if (lifechangers.Count == 0) return;
        foreach(float i in lifechangers)
        {
            if (!damageable)
            {
                break;
            }
            lifepoints = lifepoints + i;
        }

        lifechangers.Clear();

        if( gameObject.name != "Player")
        {
            if(lifepoints < 1)
            {
                Destroy(gameObject);
            }
        }
    }
}
