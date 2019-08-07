using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlantGrowth : MonoBehaviour
{
    private bool waterReceived;
    public int cycleDuration;
    public int punishmentDuration;
    public int water = 0;
    public bool wantWater;
    public bool wantFertilizer;
    public GameObject fruitPrefab;

    public GameObject waterCallout;
    public GameObject fertilizerCallout;


    public int fertilizer = 0;


    public int waterLimit = 4;

    public int fertilizerLimit = 4;
    public IEnumerator waterCycleTimer;
    public IEnumerator fertilizerCycleTimer;
    public IEnumerator punishmentTimer;
    public IEnumerator fertilizerPunishmentTimer;
    

    // Start is called before the first frame update
    void Start()
    {
        waterCycleTimer = waterCycle(cycleDuration);
        StartCoroutine(waterCycleTimer);
    }

    // Update is called once per frame
    public void Update()
    {
        if(wantWater)
        {
            waterCallout.gameObject.SetActive(true);
        }
        else
        {
            waterCallout.gameObject.SetActive(false);
        }
        if(wantFertilizer)
        {
            fertilizerCallout.gameObject.SetActive(true);
        }
        else
        {
            fertilizerCallout.gameObject.SetActive(false);
        }
 
    }



    public virtual void changePhase(int fertilizer)
    {

    }

    public virtual void disablePlantEffects()
    {

    }

    public virtual void enablePlantEffects()
    {

    }


    public void WaterManager(GameObject wat)
    {
        if(water< waterLimit)
        {
            Destroy(wat);
             
            wantWater = false;
            water++;

            if (water < waterLimit)
            {
                StopCoroutine(punishmentTimer);
                waterCycleTimer = waterCycle(cycleDuration);
                StartCoroutine(waterCycleTimer);
            }
            
        }

        if ( water == waterLimit)
        {
            StopCoroutine(punishmentTimer);
            fertilizerCycleTimer = fertilizerCycle(cycleDuration);
            StartCoroutine(fertilizerCycleTimer);
        }
    }

    public void fertilizerManager(GameObject fert)
    {
        if(fertilizer < fertilizerLimit)
        {
            Destroy(fert);
            fertilizer++;
            wantFertilizer = false;
            changePhase(fertilizer);
            StopCoroutine(fertilizerPunishmentTimer);
            water = 0;
            waterCycleTimer = waterCycle(cycleDuration);
            StartCoroutine(waterCycleTimer);
        }

        if(fertilizer == fertilizerLimit)
        {
            harvest();
        }
    }

    public virtual void harvest()
    {

    }


    public void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "water")
        {
            if(wantWater)
            {
                enablePlantEffects();
                var obj = collision.gameObject;
                WaterManager(obj);
            }
        }

        if (collision.gameObject.tag == "fertilizer")
        {
            if(wantFertilizer)
            {
                var obj = collision.gameObject;
                fertilizerManager(obj);
            }
        }
    }

    public void waterPenalty()
    {

    }


    public IEnumerator waterCycle(int duration)
    {
        yield return new WaitForSeconds(duration);
        wantWater = true;
        punishmentTimer = punishmentCycle(punishmentDuration);
        StartCoroutine(punishmentTimer);

    }

    public IEnumerator punishmentCycle(int duration)
    {
        yield return new WaitForSeconds(duration);
        if(water>0)
        { 
        water--;
        }
        //set want water to true to enable watering to reactivate
        wantWater = true;
        // set want fertilizer to false
        wantFertilizer = false;
        disablePlantEffects();

    }

    public IEnumerator fertilizerCycle(int duration)
    {
        yield return new WaitForSeconds(duration);
        wantFertilizer = true;
        fertilizerPunishmentTimer= punishmentCycle(punishmentDuration);
        StartCoroutine(fertilizerPunishmentTimer);
    }

}