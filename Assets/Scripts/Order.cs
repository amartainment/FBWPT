using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Order : MonoBehaviour
{
    public string plantName;
    public int orderDeadline;
    public Sprite orderImage;
    public int currentTick = 0;
    
    private OrderManager myOrderManager;
     GameObject UIElement;
    private bool thisOrderMissed;

    public Order(string name, int deadline, Sprite image)
    {
        plantName = name;
        orderDeadline = deadline;
        orderImage = image;
    }

    public void setOrderManager(OrderManager o)
    {
        myOrderManager = o;
    } 
  
    void OnEnable()
    {
        EventSystem.timeTick += orderTimeTick;
    }

    void OnDisable()
    {
        EventSystem.timeTick -= orderTimeTick;
    }
    void Start()
    {
        
    }

    void Update()
    {
        orderMissed();
    }

    public void setUIElement(GameObject obj)
    {
        UIElement = obj;
    }

    public void orderCompleted()
    {
        Destroy(UIElement);
    }

    void orderMissed()
    {
        if(currentTick == orderDeadline && !thisOrderMissed)
        {
            thisOrderMissed = true;
            orderCompleted();
            myOrderManager.removeFruitAt(gameObject);
            Destroy(gameObject);
            Debug.Log("Order deleted");
            EventSystem.orderMissedEvent(1);
        }
    }
    void orderTimeTick(int a)
    {
        currentTick++;
        Debug.Log(currentTick);
    }

    //add a timer, create an event called orderNotFulFilled
    //listen orderNotFulfilled in Boss/Plants/etc.
}
