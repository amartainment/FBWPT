using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrderManager : MonoBehaviour
{
    public int easeDuration;
    private int timeAlive = 0;
        bool myTimeStarted = false;

    void OnEnable()
    {
        EventSystem.timeTick += processTimeTick;
    }

    void OnDisable()
    {

    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        createOrder();
    }

    void processTimeTick(int a)
    {
        if(!myTimeStarted)
        {
            timeAlive = 0;
            myTimeStarted = true;
        } else
        {
            timeAlive++;
        }
    }

    void createOrder()
    {
        if(timeAlive%easeDuration==0 && timeAlive !=0)
        {
            Debug.Log("5");
            timeAlive = 0;
            
        }
    }
}
