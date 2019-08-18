using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VenusFlyTrap : PlantGrowth
{
    public VebusTrigger _venusTrigger;
    public BoxCollider2D triggerBox;
    public BoxCollider2D saplingTrigger;
    
    public bool enableEffects;
    Vector3 originalPosition;
    Vector3 attackDirection;
    public bool timerRunning;
    private bool waitTimeIsRunning;
     public GameObject venus;

    public Transform TriggerBox1;
    private Quaternion originalRotation;
    GameObject _player;

    public float speed;

    IEnumerator eating;
    IEnumerator waiting;
    GameObject sapling;
    public GameObject saplingPrefab;
    public GameObject actualPlant;

    

    public SpriteRenderer item;
    public SpriteRenderer item2;



    // Start is called before the first frame update
    void Start()
    {
        actualPlant.SetActive(false);
        waterCycleTimer = waterCycle(cycleDuration);
        StartCoroutine(waterCycleTimer);
        originalPosition = venus.transform.position;
        originalRotation = venus.transform.rotation;
        instantiateSapling();
    }
    // Update is called once per frame
    void Update()
    {
        base.Update();
        //if (enableEffects && !waitTimeIsRunning)
        //{
        //    getPlayer();
        //    lookAtPlayer();
        //}
    }

    void instantiateSapling()
    {
        sapling = Instantiate(saplingPrefab, transform.position, Quaternion.identity);
        sapling.transform.parent = gameObject.transform.parent;

    }

    public override void harvest()
    {
        Destroy(gameObject);
        //Instantiate Fruit.
        Vector3 offset = new Vector3(0, 1.5f, 0);
        Instantiate(fruitPrefab, transform.position + offset, Quaternion.identity);

    }

    override public void changePhase(int number)
    {
        switch (number)
        {
            case 1:
                sapling.SetActive(false);
                actualPlant.SetActive(true);
               // saplingTrigger.gameObject.SetActive(false)
                enablePlantEffects();
                break;
            case 2:
                enablePlantEffects();
                triggerBox.size = new Vector2(0.58f, 0.17f);
                TriggerBox1.localScale = new Vector2(9.3f, 9.3f);
                break;
            case 3:
                enablePlantEffects();
                triggerBox.size = new Vector2(0.59f, 0.25f);
                TriggerBox1.localScale = new Vector2(11.3f, 11.3f);
                break;
            case 4:
               // harvest();
                break;
        }
    }

    override public void disablePlantEffects()
    {
        item.color = new Color32(126, 100, 8, 255);
        item2.color = new Color32(126, 100, 8, 255);
        enableEffects = false;
    }

    override public void enablePlantEffects()
    {
        item.color = new Color32(255, 255, 255, 255);
        item2.color = new Color32(255, 255, 255, 255);
        Debug.Log("plant effects enabled");
        if (fertilizer > 0)
        {
            enableEffects = true;
        }
    }

    public void lookAtPlayer( GameObject player)
    {

        if (player != null && !timerRunning)
        {
           // StopCoroutine("waitTimer");
            attackDirection = player.transform.position;

            var targetPos = player.transform.position;
           // var venusPos = venus.transform.position - targetPos;
            var angle = Mathf.Atan2(targetPos.y, targetPos.x) * Mathf.Rad2Deg;
            venus.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            // looking = new Vector3(targetPos.x, targetPos.y, 0);

            // waiting = waitTimer();
            StartCoroutine("waitTimer");
        }

        else
        {
            Debug.Log("player is null");
        }
    }


    //public void getPlayer()
    //{
    //   _player = _venusTrigger.returnPlayer();
    //}

    public IEnumerator snapBack()
    {
        timerRunning = true;
       // StopCoroutine("waiting");
        yield return new WaitForSeconds(1f);
        // GetComponent<Rigidbody2D>().MovePosition((originalPosition));
        venus.transform.rotation = originalRotation;
        venus.transform.position = Vector2.MoveTowards(venus.transform.position, originalPosition, speed * Time.deltaTime);

        timerRunning = false;

    }

    IEnumerator waitTimer()
    {

       // StopCoroutine("snapBack");

        Debug.Log("i m in wait timer");
        //add waiting animation here
        //venus.transform.LookAt(looking);
        //venus.transform.LookAt(looking);
        yield return new WaitForSeconds(1f);

            //GetComponent<Rigidbody2D>().MovePosition(transform.position + Vector3.Normalize(attackDirection)*2f);
            // eating = snapBack();
            venus.transform.position = Vector2.MoveTowards(venus.transform.position, attackDirection, speed * Time.deltaTime);
            StartCoroutine("snapBack");
        //transform.position = transform.position + Vector3.Normalize(attackDirection) * 0.2f;
        //originalPosition = transform.position + Vector3.Normalize(attackDirection) * 0.2f;
        //if (!timerRunning)
        //{
        //    StartCoroutine("snapBack");
        //}
    }

    public void attack(GameObject player)
    {
        if (enableEffects && player != null)
        {
            lookAtPlayer(player);
        }

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
