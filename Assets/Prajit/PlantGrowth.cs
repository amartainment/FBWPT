using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantGrowth : MonoBehaviour
{
    private bool waterReceived;

    public int water = 0;

    public int fertilizer = 0;

    private bool waterRequired;

    private bool fertilizerRequired;

    private bool waterGiven;

    private bool fertilizerGiven;

    public int waterLimit = 4;

    public int fertilizerLimit = 3;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void WaterManager(GameObject wat)
    {
        if (waterRequired && water < waterLimit)
        {
            water++;
            waterRequired = false;
            Destroy(wat);
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
            fertilizerRequired = false;
            fertilizer++;
            Destroy(fert);
            StartCoroutine("waterCycle");
        }

        if (fertilizer == fertilizerLimit)
        {
            Destroy(fert);
            harvest();
        }
    }

    public void harvest()
    {
        Debug.Log("Ready to harvest");
    }


    public void OnCollisionEnter2D(Collision2D collision)
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
            if (water != 0)
            {
                water--;
            }
        }
        if(!fertilizerGiven && fertilizerRequired)
        {
            if(fertilizer!=0)
            {
                fertilizer--;
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

        yield return new WaitForSeconds(10f);
        waterPenalty();

    }
}
