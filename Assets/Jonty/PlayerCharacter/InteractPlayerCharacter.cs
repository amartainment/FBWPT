using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractPlayerCharacter : MonoBehaviour
{
    public GameObject Holding, Dispenser, Burrow;
    float Dir;

    void Update()
    {

        if (GetComponent<SpeedMovementPlayerCharacter>().Direction != 0)
        {
            Dir = Mathf.Sign(GetComponent<SpeedMovementPlayerCharacter>().Direction);
        }
        if (Holding != null)
        {
            if (Holding.GetComponent<Rigidbody2D>().isKinematic == false)
                Holding.GetComponent<Rigidbody2D>().isKinematic = true;

            Holding.transform.position = (transform.position + new Vector3((0.2f * Dir), 0.7f));
        }
        
        
    }

    public void Interact()
    {
        if (Holding == null)
        {
            //GameObject ItemDistanceCheck;
            //ItemDistanceCheck = transform.GetChild(0).GetComponent<InteractHitBox>().GetItem();

            if(transform.GetChild(0).GetComponent<InteractHitBox>().Item.Count != 0)
                CheckforItemsinHitbox();

            else if (Dispenser != null)
            {
                Vector3 SpawnPoint;
                SpawnPoint = (transform.position + new Vector3(0.2f * Dir, 0.7f));

                if (Dispenser.tag == "seeddispenser")
                    Holding = Instantiate(Dispenser.GetComponent<SeedDispenser>().Seed, SpawnPoint, Quaternion.identity);
                if (Dispenser.tag == "waterdispenser")
                    Holding = Instantiate(Dispenser.GetComponent<WaterPumpScript>().WaterBag, SpawnPoint, Quaternion.identity);
                if (Dispenser.tag == "fertilizerdispenser")
                    Holding = Instantiate(Dispenser.GetComponent<FertilizerDispenser>().Fertilizer, SpawnPoint, Quaternion.identity);
            }

            //FOR WHEN THE BURROW HAS AN INCOMPLETE TIMER

            else if(Burrow != null && Burrow.GetComponent<BurrowInteractTimer>().SeedType != null)
            {
                Debug.Log("Working on Planted Burrow");
                GameObject BurrowSeedType;
                BurrowSeedType = Burrow.GetComponent<BurrowInteractTimer>().SeedType;

                Burrow.GetComponent<BurrowInteractTimer>().TimerStart(gameObject, BurrowSeedType);
            }

                        
            
        }
        else if (Holding != null)
        {
            //TO PLANT SEEDS
            if (Holding.tag == "seed" && Burrow != null && Burrow.GetComponent<BurrowBehavior>().readyToPlant)
            {
                PlantSeed(Holding, Burrow);
            }
            else
            {
                Holding.GetComponent<Rigidbody2D>().isKinematic = false;
                Holding = null;
            }
        }

    }

    void CheckforItemsinHitbox()
    {
        
        Holding = transform.GetChild(0).GetComponent<InteractHitBox>().GetItem();

        if (Holding != null)
        {
            Holding.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
            Holding.GetComponent<Rigidbody2D>().angularVelocity = 0;
        }
    }

    void PlantSeed(GameObject PlantedSeed, GameObject B)
    {
        if (B.GetComponent<BurrowInteractTimer>().SeedType == null)
        {
            B.GetComponent<BurrowInteractTimer>().TimerStart(gameObject, PlantedSeed);

            if(Burrow.name == "Burrow")
                Holding.transform.position = B.transform.position + new Vector3 (0,1.5f,0);
            else
                Holding.transform.position = B.transform.position + new Vector3(0, 0.5f, 0);

            Holding.transform.rotation = Quaternion.Euler(0, 0, 0);
            Holding.GetComponent<CapsuleCollider2D>().enabled = false;

            Holding = null;
        }
    }
}



