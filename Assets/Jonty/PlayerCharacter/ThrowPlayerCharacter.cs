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
            HeldItem.GetComponent<Rigidbody2D>().AddForce(new Vector2(ThrowDirection.x*10, ThrowDirection.y*10));
            GetComponent<InteractPlayerCharacter>().Holding = null;
        }
    }
}
