using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrderManager : MonoBehaviour
{
    public int easeDuration;
    private int timeAlive = 0;
    bool myTimeStarted = false;
    //public List<Order> newOrderList = new List<Order>();
    private List<Order> listOfAvailablePlants = new List<Order>();

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
        //List<Order> newOrderList = new List<Order>();
    }

    // Update is called once per frame
    void Update()
    {
        CreateOrder();
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

    void CreateOrder()
    {
        if(timeAlive%easeDuration==0 && timeAlive !=0)
        {
            //Debug.Log("5");
            timeAlive = 0;
            listOfAvailablePlants.Add(new Order("Orange", 40, null));
            listOfAvailablePlants.Add(new Order("Apple", 40, null));
            listOfAvailablePlants.Add(new Order("sdf", 40, null));
            listOfAvailablePlants.Add(new Order("asdasd", 40, null));
            
        }
    }
}
