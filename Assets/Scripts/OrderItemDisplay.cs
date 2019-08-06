using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OrderItemDisplay : MonoBehaviour
{
    public Image plantSpriteDisplay;
    public Text durationTextDisplay;

    public Order newOrder;
    
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Prime(Order newOrder)
    {
        Debug.Log("Prime!");
        if(plantSpriteDisplay != null)
        {
            plantSpriteDisplay.sprite = newOrder.orderImage;  
        }
        if(durationTextDisplay != null)
        {
            durationTextDisplay.text = newOrder.orderDeadline.ToString();
        }
        newOrder.setUIElement(gameObject);
    }
}
