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
        RaycastHit2D LandedCheck = Physics2D.Raycast((transform.position- new Vector3(0, raycastoffset)), -transform.up,0.08f);
        Debug.DrawRay((transform.position - new Vector3(0, raycastoffset)), -transform.up);

        if (LandedCheck.collider != null && jumpisrecovering == false)
        {
            if(jumping == true && jumpisrecovering == false && GetComponent<SpeedMovementPlayerCharacter>().Direction == 0)
            GetComponent<Rigidbody2D>().velocity = Vector3.zero;

            jumping = false;

        }
        else if (LandedCheck.collider == null)
            jumping = true;

        
    }

    public void CharacterJump(float jumpheight)
    {

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
        GetComponent<BoxCollider2D>().isTrigger = true;
        yield return new WaitForSeconds(0.2f);
        GetComponent<BoxCollider2D>().isTrigger = false;
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