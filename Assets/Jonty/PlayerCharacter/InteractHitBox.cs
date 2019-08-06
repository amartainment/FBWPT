using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractHitBox : MonoBehaviour
{
    public List<GameObject> Item = new List<GameObject>();

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
    {
        if (Item.Contains(collision.gameObject) == false && (collision.tag == "water"|| collision.tag == "fertilizer" || collision.tag == "seed"))
            Item.Add(collision.gameObject);

        if (collision.tag == "seeddispenser")
            transform.parent.GetComponent<InteractPlayerCharacter>().Dispenser = collision.gameObject;

        if (collision.tag == "burrow")
            transform.parent.GetComponent<InteractPlayerCharacter>().Burrow = collision.gameObject;
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
