using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VebusTrigger : MonoBehaviour
{
   public VenusFlyTrap _venusFlyTrap;
    public bool playerSpotted;

    public GameObject _player;
    Transform position;
    private bool playerAlreadyInside;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player" && !_venusFlyTrap.timerRunning)
        {
            playerSpotted = true;
            _player =  collision.gameObject;
           _venusFlyTrap.attack(_player);

        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && !_venusFlyTrap.timerRunning)
        {
            playerSpotted = true;
            _player = collision.gameObject;
            _venusFlyTrap.attack(_player);
            //if(!playerAlreadyInside)
            //{
            //    StartCoroutine("playerPosition");
            //}

        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            playerSpotted = false;
            _player = null;
        }
    }

    public GameObject returnPlayer()
    {
        return _player;
    }

    public bool returnPlayerSpotted()
    {
        return playerSpotted;
    }

    IEnumerator playerPosition()
    {
        playerAlreadyInside = true;
        _venusFlyTrap.attack(_player);
        yield return new WaitForSeconds(1f);
        playerAlreadyInside = false;
    }

}
