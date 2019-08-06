using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlantGrowth : MonoBehaviour
{
    private bool waterReceived;

    public int water = 1;

    public int fertilizer = 0;

    public  bool waterRequired;

    private bool fertilizerRequired;

    private bool waterGiven;

    private bool fertilizerGiven;

    public int waterLimit = 4;

    public int fertilizerLimit = 4;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

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
        if (waterRequired && water < waterLimit)
        {
            water++;
            waterRequired = false;
            Destroy(wat);
            enablePlantEffects();
            StartCoroutine("waterCycle");

        }

        if (water == waterLimit)
        {
            Destroy(wat);
            fertilizerRequired = true;
        }
    }
    
    public void fertilizerManager(GameObject fert)
    {
        if (fertilizerRequired && fertilizer < fertilizerLimit)
        {
            water = 0;
            enablePlantEffects();
           
            fertilizerRequired = false;
            fertilizer++;
            changePhase(fertilizer);
            Destroy(fert);
            StartCoroutine("waterCycle");
        }

        if (fertilizer == fertilizerLimit)
        {
            Destroy(fert);
            harvest();
        }
    }

    public virtual void harvest()
    {
        
    }


    public void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag =="water")
        {
            waterGiven = true;
            var obj = collision.gameObject;
            WaterManager(obj);
        }

        if(collision.gameObject.tag == "fertilizer")
        {
            fertilizerGiven = true;
            var obj = collision.gameObject;
            fertilizerManager(obj);
        }
    }

    public void waterPenalty()
    {
        if(!waterGiven && waterRequired)
        {
            disablePlantEffects();
            if (water != 0)
            {
                water--;
                
            }
        }
        if(!fertilizerGiven && fertilizerRequired)
        {
            //plant effects need to be disabled even if fertilizer count is 0
            disablePlantEffects();
            if (fertilizer!=0)
            {
                fertilizer--;
                
                //call disable plant effects
                water = 3;
            }
        }
    }


    public IEnumerator waterCycle()
    {
        yield return new WaitForSeconds(5f);
        waterRequired = true;
        waterGiven = false;
        fertilizerGiven = false;

        yield return new WaitForSeconds(5f);
        waterPenalty();

    }
}
