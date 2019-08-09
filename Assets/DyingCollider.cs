﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DyingCollider : MonoBehaviour
{
    public VenusFlyTrap _venusFlyTrap;
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
        if (collision.gameObject.tag == "Player" && _venusFlyTrap.enableEffects)
        {
            Debug.Log("i m in kill box");
            collision.gameObject.GetComponent<playerController>().DieAndRespawn();
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && _venusFlyTrap.enableEffects)
        {
            Debug.Log("i m in kill box");
            collision.gameObject.GetComponent<playerController>().DieAndRespawn();
        }
    }
}
