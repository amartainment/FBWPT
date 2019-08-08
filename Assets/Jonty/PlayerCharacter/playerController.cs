using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.PlayerInput;

public class playerController : MonoBehaviour
{
    Vector2 horizontalMovement;
    bool canmove = true;
    public float jumpheight;
    float direction = 1, velocityx;
    public static bool stunned;

    //Start is called before the first frame update
    void Start()
    {
        
    }
    private void Awake()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        if(stunned == false)
        StartCoroutine(moveCoroutine(horizontalMovement));

        velocityx = GetComponent<Rigidbody2D>().velocity.x;
    }

    private void OnMove(InputValue value)
    {
        horizontalMovement = value.Get<Vector2>();
        DecideDirection(value.Get<Vector2>().x);
    }


    private void OnJoin()
    {
        Debug.Log("Player joined!");
    }
    private void OnDash()
    {
        Debug.Log("Dash");
        gameObject.GetComponent<DashPlayerCharacter>().DashPlayer(direction);
        
    }

    private void OnJump()
    {
        //Debug.Log("Jump");
        gameObject.GetComponent<JumpForceCharacter>().CharacterJump(jumpheight);
    }

    private void OnInteract()
    {
        Debug.Log("Interact");
        GetComponent<InteractPlayerCharacter>().Interact();
    }

    private void OnDeviceLost()
    {
        Destroy(gameObject);
    }

    private void OnThrow()
    {
        Debug.Log("Throw");
        GetComponent<ThrowPlayerCharacter>().ThrowHeldItem();
    }

    IEnumerator moveCoroutine(Vector2 direction)
    {
        
        
        if (direction.x == 0)
        {
            if (canmove == true)
            {
                gameObject.GetComponent<SpeedMovementPlayerCharacter>().IncreaseMovementSpeed(direction);
                gameObject.GetComponent<MovementPlayerCharacter>().MoveCharacter(direction);
            }
            canmove = false;
        }
        else
            canmove = true;

        if (canmove == true)
        {
            gameObject.GetComponent<SpeedMovementPlayerCharacter>().IncreaseMovementSpeed(direction);
            gameObject.GetComponent<MovementPlayerCharacter>().MoveCharacter(direction);
        }
        yield return new WaitForSeconds(0.01f);
    }

    void DecideDirection(float dir)
    {
        if (dir != 0)
            direction = Mathf.Sign(dir);
    }
}
