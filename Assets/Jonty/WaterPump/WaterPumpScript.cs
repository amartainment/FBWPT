using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterPumpScript : MonoBehaviour
{
    int WaterCount = 5;
    public bool Tankhaswater = true;

    public GameObject WaterBag;
    public ParticleSystem WaterParticles;
    
    public GameObject Pump(GameObject Player, Vector3 SpawnPoint)
    {
        if(Tankhaswater == true)
        {
            GameObject WaterBag;
            WaterBag = Instantiate(GetComponent<WaterPumpScript>().WaterBag, SpawnPoint, Quaternion.identity);
            WaterCount--;

            if (WaterCount <= 0)
            {
                GetComponent<SpriteRenderer>().color = new Color32(130, 130, 130, 255);
                Tankhaswater = false;
            }

            return WaterBag;
        }

        else
        {
            Instantiate(WaterParticles, transform.position + new Vector3(0, 0.3f, 0), Quaternion.identity);
            WaterCount++;
            if (WaterCount >= 5)
            {
                GetComponent<SpriteRenderer>().color = new Color32(110, 210, 210, 255);
                Tankhaswater = true;
            }



            return null;
        }
    }
}
