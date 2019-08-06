using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VenusFlyTrap : PlantGrowth
{
    // Start is called before the first frame update
    void Start()
    {
        waterCycleTimer = waterCycle(cycleDuration);
        StartCoroutine(waterCycleTimer);
    }
    // Update is called once per frame
    void Update()
    {
        
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

    }
}
