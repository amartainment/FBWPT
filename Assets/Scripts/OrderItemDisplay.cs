using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OrderItemDisplay : MonoBehaviour
{
    public Image plantSpriteDisplay;
    public Text durationTextDisplay;
    public Slider timerSlider;  
    public Order newOrder;
    public Order linkedOrder;
    public Image timeSliderFillArea;
    
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (newOrder != null)
        {
            
            timerSlider.value =  timerSlider.maxValue - linkedOrder.currentTick; 
        }

        if(timerSlider.value < timerSlider.maxValue*1/4)
        {   
            timeSliderFillArea.color = new Color32(255, 0, 0, 255);     
        }
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
        linkedOrder = newOrder;
        timerSlider.maxValue = linkedOrder.orderDeadline;
        timerSlider.minValue = 0;
        
        newOrder.setUIElement(gameObject);
    }
}
