using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementPlayerCharacter : MonoBehaviour
{
    float speed;

    private void OnEnable()
    {
        //EventSystem.Movement += MoveCharacter;
    }

    private void OnDisable()
    {
        //EventSystem.Movement -= MoveCharacter;
    }

    public void MoveCharacter(Vector2 Direction)
    {
        speed = gameObject.GetComponent<SpeedMovementPlayerCharacter>().speed;
        Debug.Log("Moving");
        transform.Translate(speed, 0, 0);      
    }
}
