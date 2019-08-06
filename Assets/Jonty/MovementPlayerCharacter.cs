using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementPlayerCharacter : MonoBehaviour
{
    float speed, direction;

    public void MoveCharacter(Vector2 Direction)
    {
        direction = Direction.x;
        speed = GetComponent<SpeedMovementPlayerCharacter>().speed;

        ChangeDirection(Direction);

        if (-speed < -20 || speed > 20)
            speed = 20 * Mathf.Sign(Direction.x);

        GetComponent<Rigidbody2D>().AddForce(new Vector2(speed, 0));
    }

    public void ChangeDirection(Vector2 dir)
    {
        if (dir.x < 0)
            transform.rotation = Quaternion.Euler(new Vector2(0,180));
        else if(dir.x > 0)
            transform.rotation = Quaternion.Euler(new Vector2(0, 0));
    }
}
