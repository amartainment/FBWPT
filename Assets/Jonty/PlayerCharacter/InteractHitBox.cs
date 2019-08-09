using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractHitBox : MonoBehaviour
{
    public List<GameObject> Item = new List<GameObject>();
    public GameObject GhostPlant, PlantedGhost, Icon, IconTemp;
    public Sprite Vines, Venus, Jumper, Wheeze;
    bool GhostPlanted = false;

    private void Update()
    {

        Vector3 Totaldirection;
        Totaldirection = transform.parent.GetComponent<MovementPlayerCharacter>().totaldirection;
        //Debug.Log("HitBoxUpdate");

        if (Totaldirection != Vector3.zero)
        {
            transform.position = ((transform.parent.position + Totaldirection * 2 / 3));
        }
        else if (Totaldirection == new Vector3(0, 0, 0) || Totaldirection == null)
        {
            if (transform.parent.GetComponent<InteractPlayerCharacter>().Holding != null)
                transform.position = transform.parent.localPosition + new Vector3(0, 0.7f);
            //transform.position = transform.parent.position + new Vector3(0, 0.7f);

        }
    }

    public GameObject GetItem()
    {
        GameObject G;
        

        if (Item.Count < 1)
        {
            GameObject Least;
            Least = Item[0];

            foreach (GameObject I in Item)
            {
                if (Vector3.Distance(I.transform.position, transform.parent.position) < Vector3.Distance(Least.transform.position, transform.parent.position))
                    Least = I;
            }
            G = Least;
        }
        else
        G = Item[0];

        return G;        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {//expanded to include fruit in first set
        if (Item.Contains(collision.gameObject) == false && (collision.tag == "water"|| collision.tag == "fertilizer" || collision.tag == "seed" || collision.tag == "fruit"))
            Item.Add(collision.gameObject);

        if (collision.tag == "seeddispenser")
        {
            IconTemp = Instantiate(Icon, collision.transform.position + new Vector3(0, 0.65f, 0), Quaternion.identity);
            transform.parent.GetComponent<InteractPlayerCharacter>().Dispenser = collision.gameObject;
        }

        if (collision.tag == "burrow")
        {
            transform.parent.GetComponent<InteractPlayerCharacter>().Burrow = collision.gameObject;

            //TO PLANT GHOST
            Debug.Log("SUMMON");
            

            if(transform.parent.GetComponent<InteractPlayerCharacter>().Holding.tag == "seed" && collision.GetComponent<BurrowInteractTimer>().SeedType == null && collision.GetComponent<BurrowBehavior>().readyToPlant == true && GhostPlanted == false)
            {
                IconTemp = Instantiate(Icon, collision.transform.position + new Vector3(0, 0.65f, 0), Quaternion.identity);

                SummonPlantGhost(transform.parent.GetComponent<InteractPlayerCharacter>().Holding, collision.gameObject);
            }
        }

        if (collision.tag == "waterdispenser")
        {
            IconTemp = Instantiate(Icon, collision.transform.position + new Vector3(0, 0.65f, 0), Quaternion.identity);
            transform.parent.GetComponent<InteractPlayerCharacter>().Dispenser = collision.gameObject;
        }

        if (collision.tag == "fertilizerdispenser")
        {
            IconTemp = Instantiate(Icon, collision.transform.position + new Vector3(0, 0.65f, 0), Quaternion.identity);
            transform.parent.GetComponent<InteractPlayerCharacter>().Dispenser = collision.gameObject;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (Item.Contains(collision.gameObject) == true)
            Item.Remove(collision.gameObject);

        if (collision.gameObject == transform.parent.GetComponent<InteractPlayerCharacter>().Dispenser)
        {
            Destroy(IconTemp);
            transform.parent.GetComponent<InteractPlayerCharacter>().Dispenser = null;
        }

        if (collision.gameObject == transform.parent.GetComponent<InteractPlayerCharacter>().Burrow)
        {
            transform.parent.GetComponent<InteractPlayerCharacter>().Burrow = null;
            if(GhostPlanted)
            {
                Destroy(PlantedGhost);
                GhostPlanted = false;

            }
            Destroy(IconTemp);

        }
    }

    void SummonPlantGhost(GameObject Seed, GameObject Burrow)
    {
        Debug.Log("Summoning Ghost");
        GhostPlanted = true;
        GhostPlant.transform.localScale = Seed.GetComponent<SeedScript>().Plant.transform.localScale;
            GhostPlant.GetComponent<SpriteRenderer>().sprite = GetSprite(Seed);
        PlantedGhost = Instantiate(GhostPlant, (Burrow.transform.position + new Vector3(0,1.5f,0)), Quaternion.identity);
    }

    Sprite GetSprite(GameObject Seed)
    {
        Sprite P;
        P = Vines;
       
        if (Seed.GetComponent<SeedScript>().SeedName == "Seed_Vines")
            P = Vines;

        if (Seed.GetComponent<SeedScript>().SeedName == "Seed_VenusFlyTrap")
        {
            GhostPlant.transform.localScale = new Vector3(3,3,3);
            P = Venus;
        }

        if (Seed.GetComponent<SeedScript>().SeedName == "Seed_JumpPad")
            P = Jumper;

        if (Seed.GetComponent<SeedScript>().SeedName == "Seed_StonedDaisy")
            P = Wheeze;

        return P;
    }
}