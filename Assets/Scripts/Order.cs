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
     GameObject UIElement;

    public Order(string name, int deadline, Sprite image)
    {
        plantName = name;
        orderDeadline = deadline;
        orderImage = image;
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
        
    }

    public void setUIElement(GameObject obj)
    {
        UIElement = obj;
    }

    public void orderCompleted()
    {
        Destroy(UIElement);
    }

    void orderTimeTick(int a)
    {
        
    }

    //add a timer, create an event called orderNotFulFilled
    //listen orderNotFulfilled in Boss/Plants/etc.
}
