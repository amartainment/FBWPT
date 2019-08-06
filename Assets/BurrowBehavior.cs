﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BurrowBehavior : MonoBehaviour
{
    // Start is called before the first frame update
    private bool readyToPlant = true;
    private bool planted = false;
    private bool plantingCoroutineIsRunning = false;
    
    public Sprite noBurrowSprite;
    Sprite burrowedSprite;
    GameObject seed;

    void Start()
    {
        burrowedSprite = GetComponent<SpriteRenderer>().sprite;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    // need to think about this function
    public void HeroInteract(GameObject equippedSeed, GameObject activePlayer)
    {
        if (readyToPlant)
        {
            //   seed = equippedSeed.GetComponent<SeedBehavior>();
            // currentPlayer = activePlayer.GetComponent<PlayerBehavior>();
            //plant a tree
            GameObject newTree = GameObject.Find("Tree1"); // get from seedBehavior attached to object - seed.treeObject;
            if (!plantingCoroutineIsRunning)
            {
                StartCoroutine(StartPlantingTimer(newTree, 1, activePlayer));
                plantingCoroutineIsRunning = true;
            }
            
            
        }

    }
    
    IEnumerator StartPlantingTimer(GameObject newTree, float plantingTime, GameObject activePlayer)
    {
        // currentPlayer = activePlayer.GetComponent<PlayerBehavior>();
        // trigger working animation in player
        yield return new WaitForSeconds(plantingTime);
        Vector3 offset = new Vector3(0, 1.5f, 0);
        Instantiate(newTree, transform.position + offset, Quaternion.identity);
        //set new tree's plot to this instance of burrow
        //newTree.getComponent<TreeBehavior>().setLinkedTile(gameObject);
        planted = true;
        readyToPlant = false;
        GetComponent<SpriteRenderer>().sprite = noBurrowSprite;
        plantingCoroutineIsRunning = false;
        //stop working animation in player

    }

    public void HarvestComplete()
    {
        GetComponent<SpriteRenderer>().sprite = burrowedSprite;
        readyToPlant = true;
        planted = false;
    }
}