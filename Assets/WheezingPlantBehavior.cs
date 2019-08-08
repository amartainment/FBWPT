using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheezingPlantBehavior : PlantGrowth
{
    public GameObject saplingPrefab;
    GameObject sapling;
    public bool plantDisabled = false;
    public GameObject actualPlant;
    Animator plantAnimator;
    int gasRelease = 0;
    bool gasCoroutineRunning = false;
    public GameObject gasPrefab;
    //animation booleans
    bool animTriggerIsPlaying = false;
    bool animIdleIsPlaying = false;
    const int STATE_IDLE = 0;
    const int STATE_TRIGGER = 1;
    int currentAnimatorState = STATE_IDLE;
    
    // Start is called before the first frame update
    void Start()
    {
        actualPlant.SetActive(false);
        waterCycleTimer = waterCycle(cycleDuration);
        StartCoroutine(waterCycleTimer);
        //instantiate sapling
        instantiateSapling();
    }

    void instantiateSapling()
    {
        
        sapling = Instantiate(saplingPrefab, transform.position, Quaternion.identity);
        sapling.transform.parent = gameObject.transform;

    }
    // Update is called once per frame
    void Update()
    {
        base.Update();   
    }

    public override void harvest()
    {
        Destroy(gameObject);
        //Instantiate Fruit.
        Vector3 offset = new Vector3(0, 0.5f, 0);
        Instantiate(fruitPrefab, transform.position + offset, Quaternion.identity);
    }

    override public void disablePlantEffects()
    {
        SpriteRenderer plantRenderer = actualPlant.GetComponent<SpriteRenderer>();
        //change color
        plantRenderer.color = new Color32(126, 100, 8, 255);
        plantDisabled = true;

    }

    override public void enablePlantEffects()
    {

        //change color
      
        SpriteRenderer plantRenderer = actualPlant.GetComponent<SpriteRenderer>();
        plantRenderer.color = new Color32(255, 255, 255, 255);
       


    }

    public override void changePhase(int fertilizer)
    {
        switch (fertilizer)
        {
            case 1:
                sapling.SetActive(false);               
                actualPlant.SetActive(true);
                plantAnimator = actualPlant.GetComponent<Animator>();
                break;
            case 2:
                gasRelease = 1;
                changeState(STATE_TRIGGER);
                //trigger animation in plant, animation event inside it will call release gas function
                break;
            case 3:
                gasRelease = 2;
                changeState(STATE_TRIGGER);
                break;
            case 4:
                break;
        }
    }

    public void releaseGas()
    {
        while(gasRelease >0 && !gasCoroutineRunning)
        {
            IEnumerator gasTimer = gasSpawnTimer(3, gasRelease);
            StartCoroutine(gasTimer);
            changeState(STATE_IDLE);
        }
       
    }

    IEnumerator gasSpawnTimer(int duration, int gasLevel)
    {
        gasCoroutineRunning = true;
        for (int i = 0; i < gasLevel; i++)
        {
            GameObject newGas = Instantiate(gasPrefab, transform.position + new Vector3( (i+1) + 0.1f, 0.1f,0),Quaternion.identity);
            GameObject newGas2 = Instantiate(gasPrefab, transform.position + new Vector3(-((i + 1) + 0.1f), 0.1f, 0), Quaternion.identity);
            yield return new WaitForSeconds(duration);
            

        }
        gasCoroutineRunning = false;
        
    }

    //animation states
    void changeState(int state)
    {

        if (currentAnimatorState == state)
            return;

        switch (state)
        {

            case STATE_IDLE:
                plantAnimator.SetInteger("state", STATE_IDLE);
                break;

            case STATE_TRIGGER:
                plantAnimator.SetInteger("state", STATE_TRIGGER);
                break;

            

        }

        currentAnimatorState = state;
    }
}
