using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.PlayerInput;

public class playerController : MonoBehaviour
{
    Vector2 horizontalMovement;
    bool canmove = true;
    public float jumpheight;
    //float moveSpeed = 10f;
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
        StartCoroutine(moveCoroutine(horizontalMovement));
    }

    private void OnMove(InputValue value)
    {
        Debug.Log("OnMoveispassed");
        horizontalMovement = value.Get<Vector2>();

        //EventSystem.Movement(value.Get<Vector2>());
        //gameObject.GetComponent<MovementPlayerCharacter>().MoveCharacter(value.Get<Vector2>());
        //gameObject.GetComponent<SpeedMovementPlayerCharacter>().IncreaseMovementSpeed(value.Get<Vector2>());
    }


    private void OnJoin()
    {
        Debug.Log("Player joined!");
    }
    private void OnDash()
    {
        Debug.Log("Dash");
    }

    private void OnJump()
    {
        Debug.Log("Jump");
        //EventSystem.Jump(jumpheight);
        gameObject.GetComponent<JumpForceCharacter>().CharacterJump(jumpheight);
    }

    private void OnInteract()
    {
        Debug.Log("Interact");
    }

    private void OnDeviceLost()
    {
        Destroy(gameObject);
    }

    IEnumerator moveCoroutine(Vector2 direction)
    {
        
        
        if (direction.x == 0)
        {
            if (canmove == true)
            {
                //EventSystem.Movement(direction);
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

            //EventSystem.Movement(direction);
        }

        //Vector3 movement = new Vector3(direction.x, 0) * moveSpeed * Time.deltaTime;
        //transform.position = transform.position + movement;

        yield return new WaitForEndOfFrame();
    }
}
