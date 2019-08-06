using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Order : MonoBehaviour
{
    public string plantName;
    public int orderDeadline;
    public Sprite orderImage;
    public int currentTick;
     GameObject UIElement;

    public Order(string name, int deadline, Sprite image)
    {
        plantName = name;
        orderDeadline = deadline;
        orderImage = image;
    }
    void Start()
    {
        

    }

    void Update()
    {
        
    }

    public void setUIElement(GameObject obj)
    {
        UIElement = obj;
    }

    public void orderCompleted()
    {
        Destroy(UIElement);
    }

    
    //add a timer, create an event called orderNotFulFilled
    //listen orderNotFulfilled in Boss/Plants/etc.
}
