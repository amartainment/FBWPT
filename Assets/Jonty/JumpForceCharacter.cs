using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpForceCharacter : MonoBehaviour
{
    bool jumping = false, jumpisrecovering = false;
    public Rigidbody2D JumpRB;
    public float jumpheight;
    public float delay;

    private void OnEnable()
    {
        //EventSystem.Jump += CharacterJump;
    }

    public void CharacterJump(float jumpheight)
    {
        Debug.Log("JumpCall");

        if (jumping == false)
        {
            jumping = true;
            JumpRB.AddForce(new Vector2(0, jumpheight*100));
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
        waitagain:
        yield return new WaitForSeconds(delay);
        Debug.Log(gameObject.GetComponent<Rigidbody2D>().velocity.y);
        if (gameObject.GetComponent<Rigidbody2D>().velocity.y == 0)
            jumping = false;
        else
            goto waitagain;
        jumpisrecovering = false;        
    }

}