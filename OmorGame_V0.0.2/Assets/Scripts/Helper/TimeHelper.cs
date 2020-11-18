using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class TimeHelper 
{
    public static bool ToZeroTimer(this ref float temptime)
    {
        temptime = temptime - Time.fixedDeltaTime;
        if(temptime<= 0)
        {
            temptime = 0;
            return true;
        }

        return false;
    }
}
