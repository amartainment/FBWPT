﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VebusTrigger : MonoBehaviour
{
    VenusFlyTrap _venusFlyTrap;
    public bool playerSpotted;

    public GameObject _player;
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
        if(collision.gameObject.tag == "Player")
        {
            playerSpotted = true;
            _player =  collision.gameObject;
            //_venusFlyTrap.attack();

        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            playerSpotted = true;
            _player = collision.gameObject;
           // _venusFlyTrap.attack();

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
}
