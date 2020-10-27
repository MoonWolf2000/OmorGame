using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class StatusManager : MonoBehaviour
{
    public Status[] stati = new Status[2];
    public Status activeStatus;
    MoveController mc;
    private int statusNumber = 0;

    private void Start()
    {
        
        mc = gameObject.GetComponent<MoveController>();
        mc.speed = activeStatus.speeeeeeed;
        ValuesChanger();

    }

    public void StatusChanger(InputAction.CallbackContext context)
    {
        switch(context.action.name)
        {
            case "SC1":
                statusNumber = 0;
                break;
            case "SC2":
                statusNumber = 1;
                break;
        }


        if (context.action.ReadValue<float>() > 0)
        {
            mc.moving = false;
            activeStatus = stati[statusNumber];
            ValuesChanger();
            mc.moving = true;
        }
    }

    public void ValuesChanger()
    {
        mc.speed = activeStatus.speeeeeeed;
        gameObject.GetComponent<SpriteRenderer>().color = activeStatus.color;
        
    }

    public enum speed
    {
        slow = 3,
        medium = 6,
        fast = 10,
    }

    public enum weapon
    {
        slowGun,
        fastGun,
    }
}


