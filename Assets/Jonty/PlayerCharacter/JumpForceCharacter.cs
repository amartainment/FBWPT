using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class JumpForceCharacter : MonoBehaviour
{
    public bool jumping = false;
    bool jumpisrecovering = false;
    public Rigidbody2D JumpRB;
    public float delay;

    public float raycastoffset=0.8f;


    private void FixedUpdate()
    {
        //Debug.Log("Vertical velocity " + GetComponent<Rigidbody2D>().velocity.y);

        //TURN COLLISION WITH PLATFORMS OFF
        if(GetComponent<Rigidbody2D>().velocity.y > 0)
        Physics2D.IgnoreCollision(GameObject.Find("Collideable").GetComponent<TilemapCollider2D>(), GetComponent<CapsuleCollider2D>());

        if (GetComponent<Rigidbody2D>().velocity.y <= 0)
        {
            //TURN COLLISION WITH PLATFORMS BACK ON WHEN GAMEOBJECT IS FALLING
            Physics2D.IgnoreCollision(GameObject.Find("Collideable").GetComponent<TilemapCollider2D>(), GetComponent<CapsuleCollider2D>(), false);

            RaycastHit2D LandedCheck = Physics2D.Raycast((transform.position - new Vector3(0, raycastoffset)), -transform.up, 0.08f);
            Debug.DrawRay((transform.position - new Vector3(0, raycastoffset)), -transform.up);

            if (LandedCheck.collider != null && jumpisrecovering == false)
            {
                if (jumping == true && jumpisrecovering == false && GetComponent<SpeedMovementPlayerCharacter>().Direction == 0)
                    GetComponent<Rigidbody2D>().velocity = Vector3.zero;

                jumping = false;
            }
            else if (LandedCheck.collider == null)
                jumping = true;
        }




        //Debug.Log(Physics2D.GetIgnoreCollision(GameObject.Find("Collideable").GetComponent<TilemapCollider2D>(), GetComponent<CapsuleCollider2D>()));
    }

    public void CharacterJump(float jumpheight)
    {

        if (jumping == false)
        {
            jumpisrecovering = true;
            jumping = true;

            

            JumpRB.AddForce(new Vector2(0, jumpheight *100));            

            StartCoroutine(JumpisRecovering());            
        }
    }

    IEnumerator JumpisRecovering()
    {
        //GetComponent<BoxCollider2D>().isTrigger = true;
        yield return new WaitForSeconds(0.2f);
        //GetComponent<BoxCollider2D>().isTrigger = false;
        jumpisrecovering = false;
    }
}