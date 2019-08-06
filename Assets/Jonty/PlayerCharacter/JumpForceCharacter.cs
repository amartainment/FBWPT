using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpForceCharacter : MonoBehaviour
{
    public bool jumping = false;
    bool jumpisrecovering = false;
    public Rigidbody2D JumpRB;
    public float jumpheight;
    public float delay;

    public float raycastoffset=0.8f;


    private void Update()
    {
        RaycastHit2D LandedCheck = Physics2D.Raycast((transform.position- new Vector3(0, raycastoffset)), -transform.up, 0.1f);
        Debug.DrawRay((transform.position - new Vector3(0, raycastoffset)), -transform.up);
        if (LandedCheck.collider != null && jumpisrecovering == false)
        {
            jumping = false;
            //Debug.Log("Landed Check " + LandedCheck.distance);
        }
        else if (LandedCheck.collider == null)
            jumping = true;

        
    }

    public void CharacterJump(float jumpheight)
    {
        //Debug.Log("JumpCall");

        if (jumping == false)
        {
            jumpisrecovering = true;
            jumping = true;
            JumpRB.AddForce(new Vector2(0, jumpheight*100));
            StartCoroutine(JumpisRecovering());
        }
    }

    IEnumerator JumpisRecovering()
    {
        yield return new WaitForSeconds(0.2f);
        jumpisrecovering = false;
    }

    
    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    if (jumpisrecovering == false)
    //        StartCoroutine(JumpRecovery());
    //}

    //IEnumerator JumpRecovery()
    //{
    //    //Debug.Log("JumpRecovery");
    //    jumpisrecovering = true;
    //    waitagain:
    //    yield return new WaitForSeconds(delay);
    //    //Debug.Log(gameObject.GetComponent<Rigidbody2D>().velocity.y);
    //    if (gameObject.GetComponent<Rigidbody2D>().velocity.y == 0)
    //        jumping = false;
    //    else
    //        goto waitagain;
    //    jumpisrecovering = false;        
    //}

}