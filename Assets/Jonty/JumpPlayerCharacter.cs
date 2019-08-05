using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpPlayerCharacter : MonoBehaviour
{
    bool jumping = false, jumpisrecovering = false;
    float jumpinstance = 0, jumpadadjust = 30;

    private void OnEnable()
    {
        EventSystem.Jump += CharacterJump;
    }

    void CharacterJump(float jumpheight)
    {
        if (jumping == false && jumpinstance < jumpheight)
            StartCoroutine(AdjustJump(jumpheight));
    }

    IEnumerator AdjustJump(float heightofjump)
    {
        jumping = true;
        int jumpadjustmodifier = -1;
        while (jumpinstance < heightofjump && jumpadadjust > 0)
        {
            Debug.Log("jumping");

            transform.Translate(0, heightofjump * jumpadadjust / 100, 0);

            jumpadjustmodifier -= -1;
            jumpadadjust -= 8 + jumpadjustmodifier;

            Debug.Log(heightofjump * jumpadadjust / 100);
            jumpinstance += heightofjump * jumpadadjust / 100;
            yield return new WaitForEndOfFrame();
        }
        
        jumping = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (gameObject.GetComponent<Rigidbody2D>().velocity.y == 0 && jumpisrecovering == false)
            StartCoroutine(JumpRecovery());
    }

    IEnumerator JumpRecovery()
    {
        jumpisrecovering = true;
        yield return new WaitForSeconds(0.3f);
        if (gameObject.GetComponent<Rigidbody2D>().velocity.y == 0)
            jumping = false;
        jumpisrecovering = false;
        jumpadadjust = 8;
        jumpinstance = 30;
    }

}
