using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashPlayerCharacter : MonoBehaviour
{
    public float dashdistance, direction1;
    bool canDash = true, collidedwithotherplayer = false, dashing = false;

    public void DashPlayer(float direction)
    {
        direction1 = Mathf.Sign(direction);
        if(canDash == true)
        StartCoroutine(Dash(direction));
    }

    IEnumerator Dash(float dir)
    {
        float gravityscale = GetComponent<Rigidbody2D>().gravityScale;

        canDash = false;
        dashing = true;
        GetComponent<Rigidbody2D>().gravityScale = 0;

        GetComponent<Rigidbody2D>().velocity = Vector3.zero;
        GetComponent<Rigidbody2D>().AddForce(new Vector2(dir * dashdistance, 0));
        for (int i = 0; i < 15; i++)
        {
            if (collidedwithotherplayer == true)
                break;

            yield return new WaitForSeconds(0.001f);
        }

        GetComponent<Rigidbody2D>().velocity = Vector3.zero;
        //GetComponent<Rigidbody2D>().velocity = (GetComponent<Rigidbody2D>().velocity)/5;

        GetComponent<Rigidbody2D>().gravityScale = gravityscale;
        dashing = false;

        if (collidedwithotherplayer == true)
            StartCoroutine(Stunned(dir));
        else
            StartCoroutine(RecoverDash());
    }
    
    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.tag == "Player" && canDash == false)
            collidedwithotherplayer = true;
        if(collision.gameObject.tag == "Player" && collision.gameObject.GetComponent<DashPlayerCharacter>().dashing == true)
        {
            collidedwithotherplayer = true;
            StartCoroutine(Stunned(collision.gameObject.GetComponent<DashPlayerCharacter>().direction1));
        }
    }

    IEnumerator RecoverDash()
    {
        yield return new WaitForSeconds(.4f);
        while (GetComponent<JumpForceCharacter>().jumping == true)
           yield return new WaitForEndOfFrame();

        canDash = true;
    }
        

    IEnumerator Stunned(float d)
    {
        playerController.stunned = true;
        gameObject.GetComponent<SpeedMovementPlayerCharacter>().speed = 0;
        transform.Translate(0, 0.5f, 0);

        GetComponent<Rigidbody2D>().velocity = Vector3.zero;

        GetComponent<Rigidbody2D>().AddForce(new Vector3(-80*direction1, 10, 0));

        yield return new WaitForSeconds(0.3f);
        GetComponent<Rigidbody2D>().velocity = Vector3.zero;

        playerController.stunned = false;
        collidedwithotherplayer = false;
        StartCoroutine(RecoverDash());
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
            collidedwithotherplayer = true;

        if (collision.gameObject.tag == "Player" && collision.gameObject.GetComponent<DashPlayerCharacter>().dashing == true)
        {
            StartCoroutine(Stunned(collision.gameObject.GetComponent<DashPlayerCharacter>().direction1));
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
            collidedwithotherplayer = false;
    }
}
