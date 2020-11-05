using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeController : MonoBehaviour
{
    public float lifepoints = 15;
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
            Debug.Log("I did damage");
            Debug.Log(damageable);

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
