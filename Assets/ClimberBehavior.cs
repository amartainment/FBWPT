using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClimberBehavior : PlantGrowth
{
    bool plantDisabled = false;
    public GameObject fruit;
    public GameObject vineSegment;
    public GameObject saplingPrefab;
    GameObject sapling;

    // Start is called before the first frame update
    void Start()
    {
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
        
    }

    public override void harvest()
    {
        Destroy(gameObject);
        //Instantiate Fruit.
        Vector3 offset = new Vector3(0, 0.5f, 0);
        Instantiate(fruitPrefab, transform.position + offset, Quaternion.identity);
        


    }
    override public void changePhase(int number)
    {
       
        switch(number)
        {
            
            case 1:
                //stage 1
                sapling.SetActive(false);
                Vector3 offset = new Vector3(0, 0.5f,0);
                GameObject wine = Instantiate(vineSegment, transform.position + offset, Quaternion.identity);
                wine.transform.parent = gameObject.transform;
                break;
            case 2:
                //stage 2
                Vector3 offset2 = new Vector3(0, 2.5f, 0);
                GameObject wine2 = Instantiate(vineSegment, transform.position + offset2, Quaternion.identity);
                wine2.transform.parent = gameObject.transform;
                break;
            case 3:
                Vector3 offset3 = new Vector3(0, 4.5f, 0);
                GameObject wine3 = Instantiate(vineSegment, transform.position + offset3, Quaternion.identity);
                wine3.transform.parent = gameObject.transform;
                //stage 3
                break;
            case 4:
                //harvest

                break;

        }
    }

    override public void disablePlantEffects()
    {
        SpriteRenderer[] leavesAndStems = GetComponentsInChildren<SpriteRenderer>();
        ClimberLeafBehavior[] leaves = GetComponentsInChildren<ClimberLeafBehavior>();
        //wilt() leaves and change color
        //disable platforms
        foreach ( ClimberLeafBehavior leaf in leaves)
        {
            leaf.Wilt();
        }
        //change color
        foreach (SpriteRenderer item in leavesAndStems)
        {
            item.color = new Color32(126, 100, 8, 255);
        }
        plantDisabled = true;
        
    }

    override public void enablePlantEffects()
    {
        
            //bloom() leaves and change color
            ClimberLeafBehavior[] leaves = GetComponentsInChildren<ClimberLeafBehavior>();
            SpriteRenderer[] leavesAndStems = GetComponentsInChildren<SpriteRenderer>();
            foreach (ClimberLeafBehavior leaf in leaves)
            {
                leaf.Bloom();
            }

            foreach (SpriteRenderer item in leavesAndStems)
            {
                item.color = new Color32(255, 255, 255, 255);
            }
        
        
       
    }
}
