﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedMovementPlayerCharacter : MonoBehaviour
{
    public float speed, maxspeed, acceleration;
    bool AccelerateisRunning = false, DecelerateisRunning;


    private void OnEnable()
    {
        //EventSystem.Movement += IncreaseMovementSpeed;
        //EventSystem.MovementEnd += ResetCharacter;
    }


    public void IncreaseMovementSpeed(Vector2 direction)
    {
        if(direction.x == 0)
            StartCoroutine(Decelerate());

        else // if (AccelerateisRunning == false)
        {            
            StartCoroutine(Accelerate(direction));
        }
    }

    IEnumerator Accelerate(Vector2 dir)
    {
        Debug.Log("Accelerating");

        AccelerateisRunning = true;
        DecelerateisRunning = false;

        if (speed > -maxspeed && speed < maxspeed)
            speed += acceleration*(Mathf.Sign(dir.x));
        else
            StartCoroutine(Decelerate());


        yield return new WaitForEndOfFrame();
        AccelerateisRunning = false;
    }


    void ResetCharacter()
    {
       StartCoroutine(Decelerate());
    }

    IEnumerator Decelerate()
    {
        //Debug.Log("Decelerating");

        DecelerateisRunning = true;
        while ((-0.005f > speed || speed > 0.005f) && DecelerateisRunning == true)
        {
            //Debug.Log("Decelerating loop");
            if (speed < 0)
                speed += acceleration;
            else if (speed > 0)
                speed -= acceleration;
            transform.Translate(speed, 0, 0);
            yield return new WaitForEndOfFrame();
        }
    }

}
