using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowPlayerCharacter : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public  void ThrowHeldItem()
    {
        Vector3 ThrowDirection;
        ThrowDirection = GetComponent<MovementPlayerCharacter>().totaldirection;

        GameObject HeldItem;
        HeldItem = GetComponent<InteractPlayerCharacter>().Holding;

        if(HeldItem != null)
        {
            GameObject ThrownItem;
            int xdirection = 1;
            ThrownItem = HeldItem;

            if (ThrowDirection.x < 0)
                xdirection = -1;
            else if (ThrowDirection.x == 0)
                xdirection = 0;
            
            GetComponent<InteractPlayerCharacter>().Holding = null;

            ThrownItem.GetComponent<Rigidbody2D>().isKinematic = false;
            ThrownItem.GetComponent<Collider2D>().enabled = true;

            ThrownItem.GetComponent<Rigidbody2D>().AddForce((ThrownItem.transform.position - transform.position) *1000);
            //ThrownItem.GetComponent<Rigidbody2D>().AddForce(new Vector2(600* xdirection, ((200 * ThrowDirection.y) + 300)));

            Debug.Log("Threw "+ ThrownItem.name);
        }
    }
}
