using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractHitBox : MonoBehaviour
{
    public List<GameObject> Item = new List<GameObject>();


    private void Update()
    {

        Vector3 Totaldirection;
        Totaldirection = transform.parent.GetComponent<MovementPlayerCharacter>().totaldirection;
        Debug.Log("HitBoxUpdate");

        if (Totaldirection != Vector3.zero)
        {
            transform.position = ((transform.parent.position + Totaldirection * 2 / 3));
        }
        else if (Totaldirection == new Vector3(0, 0, 0) || Totaldirection == null)
        {
            if (transform.parent.GetComponent<InteractPlayerCharacter>().Holding != null)
                transform.position = transform.parent.position + new Vector3(0, 0.7f);
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
            transform.parent.GetComponent<InteractPlayerCharacter>().Dispenser = collision.gameObject;

        if (collision.tag == "burrow")
            transform.parent.GetComponent<InteractPlayerCharacter>().Burrow = collision.gameObject;

        if (collision.tag == "waterdispenser")
            transform.parent.GetComponent<InteractPlayerCharacter>().Dispenser = collision.gameObject;

        if (collision.tag == "fertilizerdispenser")
            transform.parent.GetComponent<InteractPlayerCharacter>().Dispenser = collision.gameObject;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (Item.Contains(collision.gameObject) == true)
            Item.Remove(collision.gameObject);

        if (collision.gameObject == transform.parent.GetComponent<InteractPlayerCharacter>().Dispenser)
            transform.parent.GetComponent<InteractPlayerCharacter>().Dispenser = null;

        if (collision.gameObject == transform.parent.GetComponent<InteractPlayerCharacter>().Burrow)
            transform.parent.GetComponent<InteractPlayerCharacter>().Burrow = null;
    }
}