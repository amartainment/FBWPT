using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClimberLeafBehavior : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Wilt()
    {
        if (transform.localScale.x < 0)
        {
         transform.eulerAngles = new Vector3(0,0,-90);  
        }


        if (transform.localScale.x > 0)
        {
            transform.eulerAngles = new Vector3(0, 0, 90);
        }

        GetComponent<BoxCollider2D>().enabled = false;
    }

    public void Bloom()
    {
        transform.eulerAngles = new Vector3(0, 0, 0);
        GetComponent<BoxCollider2D>().enabled = true;
        
    }
}
