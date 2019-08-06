using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Order
{
    public string plantName;
    public int orderDeadline;
    public Sprite orderImage;

    public Order(string name, int deadline, Sprite image)
    {
        plantName = name;
        orderDeadline = deadline;
        orderImage = image;
    }

}
