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
        if (waterRequired && water < 4)
        {
            water++;
            waterRequired = false;
            Destroy(wat);
            StartCoroutine("waterCycle");

        }

        if (water == 4)
        {
            Destroy(wat);
            fertilizerRequired = true;
        }
    }

    public void fertilizerManager(GameObject fert)
    {
        if (fertilizerRequired && fertilizer < 2)
        {
            water = 0;
            fertilizer++;
            Destroy(fert);
            StartCoroutine("waterCycle");
        }

        if (fertilizer == 3)
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
            Debug.Log("colliding water");
            var obj = collision.gameObject;
            WaterManager(obj);
        }

        if(collision.gameObject.tag == "fertilizer")
        {
            Debug.Log("colliding fertilizer");
            var obj = collision.gameObject;
            fertilizerManager(obj);
        }
    }



    public IEnumerator waterCycle()
    {
        yield return new WaitForSeconds(5f);
        waterRequired = true;
    }
}
