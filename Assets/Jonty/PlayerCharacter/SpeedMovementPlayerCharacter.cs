using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedMovementPlayerCharacter : MonoBehaviour
{
    public float speed, maxspeed, acceleration;
    bool AccelerateisRunning = false, DecelerateisRunning;
    public float Direction;

    public void IncreaseMovementSpeed(Vector2 direction)
    {
        Direction = direction.x;
        //Debug.Log("Direction x "+ direction.x);
        if (direction.x == 0 || (direction.x < 0.3f && direction.x > -0.3f))
        {
            
            StartCoroutine(Decelerate());
        }

        else
        {
            StartCoroutine(Accelerate(direction));
        }
    }

    IEnumerator Accelerate(Vector2 dir)
    {
        //Debug.Log("CoroutineAccelerate");

        AccelerateisRunning = true;
        DecelerateisRunning = false;

            if (Mathf.Sign(dir.x) == -1 && GetComponent<Rigidbody2D>().velocity.x > -maxspeed)
                speed += acceleration * (Mathf.Sign(dir.x));
            else if (Mathf.Sign(dir.x) == 1 && GetComponent<Rigidbody2D>().velocity.x < maxspeed)
                speed += acceleration * (Mathf.Sign(dir.x));
            else
            speed = GetComponent<Rigidbody2D>().velocity.x/10 * -acceleration;


        yield return new WaitForEndOfFrame();
        AccelerateisRunning = false;
    }


    IEnumerator Decelerate()
    {
        DecelerateisRunning = true;
        int count;
        count = 5;
        while ((-1.5f > GetComponent<Rigidbody2D>().velocity.x || GetComponent<Rigidbody2D>().velocity.x > 1.5f) && DecelerateisRunning == true)
        {

            //Debug.Log("Decelerating loop");

            speed = GetComponent<Rigidbody2D>().velocity.x * acceleration;
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(-speed, 0));

            yield return new WaitForEndOfFrame();
            count--;
            if (-0.5f > GetComponent<Rigidbody2D>().velocity.x && GetComponent<Rigidbody2D>().velocity.x > 0.5f && Direction == 0)
            {
                GetComponent<Rigidbody>().velocity = Vector3.zero;
                break;
            }
        }

        if (DecelerateisRunning == true)
        {
            //Debug.Log("Stopped");
            GetComponent<Rigidbody2D>().velocity = new Vector2(0, GetComponent<Rigidbody2D>().velocity.y);
            GetComponent<Rigidbody2D>().angularVelocity = 0;
            speed = 0;
        }
    }


}
