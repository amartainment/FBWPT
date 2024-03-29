﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VenusFlyTrap : PlantGrowth
{
    public VebusTrigger _venusTrigger;
    public BoxCollider2D triggerBox;
    
    private bool enableEffects;
    Vector3 originalPosition;
    Vector3 attackDirection;
    private bool timerRunning;
    private bool waitTimeIsRunning;

    GameObject _player;

    // Start is called before the first frame update
    void Start()
    {
        waterCycleTimer = waterCycle(cycleDuration);
        StartCoroutine(waterCycleTimer);
        originalPosition = transform.position;
    }
    // Update is called once per frame
    void Update()
    {
        base.Update();
        if (enableEffects && !waitTimeIsRunning)
        {
            getPlayer();
            lookAtPlayer();
        }
    }


    public override void harvest()
    {
        Destroy(gameObject);
        //Instantiate Fruit.
        Debug.Log("Ready to harvest");

    }

    override public void changePhase(int number)
    {
        switch (number)
        {
            case 1:
                enablePlantEffects();
                break;
            case 2:
                enablePlantEffects();
                triggerBox.size = new Vector2(5.5f, 1.7f);
                break;
            case 3:
                enablePlantEffects();
                triggerBox.size = new Vector2(6.5f, 1.7f);
                break;
            case 4:
                harvest();
                break;
        }
    }

    override public void disablePlantEffects()
    {
        enableEffects = false;
    }

    override public void enablePlantEffects()
    {
        Debug.Log("plant effects enabled");
        if (fertilizer > 0)
        {
            enableEffects = true;
        }
    }

    public void lookAtPlayer()
    {

        if (_player != null)
        {

            attackDirection = _player.transform.position - transform.position;
            StartCoroutine("waitTimer");


        }

        else
        {
            Debug.Log("player is null");
        }
    }

    public void rotateHead(GameObject _player)
    {

    }

    public void getPlayer()
    {
       _player = _venusTrigger.returnPlayer();
    }

    public IEnumerator snapBack()
    {
        timerRunning = true;
        yield return new WaitForSeconds(1f);
        GetComponent<Rigidbody2D>().MovePosition((originalPosition));
        timerRunning = false;

    }

    IEnumerator waitTimer()
    {
        waitTimeIsRunning = true;
        Debug.Log("i m in wait timer");
        //add waiting animation here
        yield return new WaitForSeconds(0.03f);
        GetComponent<Rigidbody2D>().MovePosition(transform.position + Vector3.Normalize(attackDirection) * 0.2f);


        //transform.position = transform.position + Vector3.Normalize(attackDirection) * 0.2f;
        //originalPosition = transform.position + Vector3.Normalize(attackDirection) * 0.2f;
        if (!timerRunning)
        {
            StartCoroutine("snapBack");
        }
        Debug.Log("attack direction" + attackDirection);
        Debug.Log("gameobject" + gameObject);
        Debug.Log("player" + _player);
        waitTimeIsRunning = false;
    }

    public void attack()
    {

    }

    //override public void OnTriggerStay2D(Collider2D collision)
    //{
    //    if (collision.gameObject.tag == "water")
    //    {
    //        if (wantWater)
    //        {
    //            enablePlantEffects();
    //            var obj = collision.gameObject;
    //            WaterManager(obj);
    //        }
    //    }

    //    if (collision.gameObject.tag == "bee")
    //    {
    //        if (wantFertilizer)
    //        {
    //            var obj = collision.gameObject;
    //            fertilizerManager(obj);
    //        }
    //    }
    //}
}
