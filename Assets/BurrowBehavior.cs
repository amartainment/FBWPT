using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BurrowBehavior : MonoBehaviour
{
    // Start is called before the first frame update
    public bool readyToPlant = true;
    private bool planted = false;
    private bool plantingCoroutineIsRunning = false;
    public GameObject plant;
    public Sprite noBurrowSprite;
    public Sprite burrowedSprite;
    SeedScript seed;
    public Vector3 offset;

    void Start()
    {
        
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
            seed = equippedSeed.GetComponent<SeedScript>();
            // currentPlayer = activePlayer.GetComponent<PlayerBehavior>();
            //plant a tree
            GameObject newTree = seed.Plant; ; // get from seedBehavior attached to object - seed.treeObject;
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
        
        GameObject plantedTree = Instantiate(newTree, transform.position + offset, Quaternion.identity);
        //set new tree's plot to this instance of burrow
        //newTree.getComponent<TreeBehavior>().setLinkedTile(gameObject);
        plantedTree.GetComponent<PlantGrowth>().setBurrow(gameObject);
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
