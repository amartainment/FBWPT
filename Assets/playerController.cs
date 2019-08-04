using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.PlayerInput;

public class playerController : MonoBehaviour
{
    Vector2 horizontalMovement;
    float moveSpeed = 10f;  
    // Start is called before the first frame update
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
        horizontalMovement = value.Get<Vector2>();
        
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
        
        Vector3 movement = new Vector3(direction.x, 0)*moveSpeed*Time.deltaTime;
        transform.position = transform.position + movement;
        yield return new WaitForEndOfFrame();
    }
}
