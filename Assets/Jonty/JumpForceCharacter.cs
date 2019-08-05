using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpForceCharacter : MonoBehaviour
{
    bool jumping = false, jumpisrecovering = false;
    public Rigidbody2D JumpRB;

    private void OnEnable()
    {
        EventSystem.Jump += CharacterJump;
    }

    void CharacterJump(float jumpheight)
    {
        Debug.Log("JumpCall");

        if (jumping == false)
        {
            jumping = true;
            JumpRB.AddForce(new Vector2(0, 500));
            Debug.Log("Jumping");
        }
    }

    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (jumpisrecovering == false)
            StartCoroutine(JumpRecovery());
    }

    IEnumerator JumpRecovery()
    {
        Debug.Log("JumpRecovery");
        jumpisrecovering = true;
        yield return new WaitForSeconds(0.5f);
        Debug.Log(gameObject.GetComponent<Rigidbody2D>().velocity.y);
        if (gameObject.GetComponent<Rigidbody2D>().velocity.y == 0)
            jumping = false;
        jumpisrecovering = false;        
    }

}