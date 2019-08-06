using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClimberBehavior : PlantGrowth
{
    bool plantDisabled = false;
    // Start is called before the first frame update
    void Start()
    {
        waterRequired = true;
        StartCoroutine(waterCycle());
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

    }

    override public void disablePlantEffects()
    {
        Debug.Log("disable specific");
        ClimberLeafBehavior[] leaves = GetComponentsInChildren<ClimberLeafBehavior>();
        foreach( ClimberLeafBehavior leaf in leaves)
        {
            leaf.Wilt();
        }
        plantDisabled = true;
    }

    override public void enablePlantEffects()
    {
        if (plantDisabled)
        {
            ClimberLeafBehavior[] leaves = GetComponentsInChildren<ClimberLeafBehavior>();
            foreach (ClimberLeafBehavior leaf in leaves)
            {
                leaf.Bloom();
            }
        }
    }
}
