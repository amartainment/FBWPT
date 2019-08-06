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
            Holding.transform.position = (transform.position + new Vector3((0.2f * Dir), 0.7f));
        }
    }

    public void Interact()
    {
        if (Holding == null)
        {
            Vector3 SpawnPoint;
            SpawnPoint = (transform.position + new Vector3(0.2f * Dir, 0.7f));

            if (Dispenser != null)
            {
                if (Dispenser.tag == "seeddispenser")
                    Holding = Instantiate(Dispenser.GetComponent<SeedDispenser>().Seed, SpawnPoint, Quaternion.identity);
                if (Dispenser.tag == "waterdispenser")
                    Holding = Instantiate(Dispenser.GetComponent<WaterPumpScript>().WaterBag, SpawnPoint, Quaternion.identity);
                if (Dispenser.tag == "fertilizerdispenser")
                    Holding = Instantiate(Dispenser.GetComponent<FertilizerDispenser>().Fertilizer, SpawnPoint, Quaternion.identity);
            }
            else
            {
                CheckforItemsinHitbox();
                
            }
        }
        else if (Holding != null)
        {
            if(Holding.tag == "seed" && Burrow != null)
            {
                Burrow.GetComponent<BurrowBehavior>().HeroInteract(Holding, gameObject);
                Destroy(Holding.gameObject);
            }
            
            Holding = null;
        }

    }

    void CheckforItemsinHitbox()
    {
        Holding = transform.GetChild(0).GetComponent<InteractHitBox>().GetItem();
    }
}

