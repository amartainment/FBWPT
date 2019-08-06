using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class burrowTestHeroCOde : MonoBehaviour
{
    //Booleans to test proximity to things - This should ideally become an interactions class as we move ahead
    bool nearABurrow = false;
    BurrowBehavior thisBurrow;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("burrow"))
        {
            
            thisBurrow = collision.gameObject.GetComponent<BurrowBehavior>();
            nearABurrow = true;
            
        }
    }

    private void OnInteract()
    {
        if (nearABurrow)
        {
            GameObject seed = new GameObject();
            thisBurrow.HeroInteract(seed, gameObject);

        }
    }
    // to be removed after testing! function to be called in the harvest function of a tree
    private void OnJump ()
    {
        if(nearABurrow)
        {
            thisBurrow.HarvestComplete();
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("burrow"))
        {
            nearABurrow = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("burrow"))
        {
            nearABurrow = false;
            thisBurrow = null;
        }
    }
}
