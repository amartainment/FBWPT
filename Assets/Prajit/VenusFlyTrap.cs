using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VenusFlyTrap : PlantGrowth
{
    public VebusTrigger _venusTrigger;
    GameObject _player;
    private bool enableEffects;
    Vector3 originalPosition;
    Vector3 attackDirection;
    private bool timerRunning;

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
        if(enableEffects)
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
                break;
            case 3:
                enablePlantEffects();
                break;
            case 4:
                harvest();
                break;
        }
    }

    override public void disablePlantEffects()
    {

    }

    override public void enablePlantEffects()
    {
        Debug.Log("plant effects enabled");
        enableEffects = true;
    }

    public void lookAtPlayer()
    {

        if (_player != null)
        {

            attackDirection = _player.transform.position - transform.position;
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
}
