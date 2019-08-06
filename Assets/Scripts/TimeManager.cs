using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class TimeManager : MonoBehaviour
{
    public int timeInterval;
    public float timer;
    public int timeCounter;
    public Text textElement;
    public int levelTime;
    //public UnityEvent timeTick;

    void Start()
    {
        timer = 0;
        StartCoroutine(CreateTimerTick(timeInterval));
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime/timeInterval;
        timeCounter = Mathf.RoundToInt(timer);
        //textElement.text = timeCounter.ToString();
        //Trigger the Time Tick event
        //EventSystem.timeTick();
        
    }

  
    IEnumerator CreateTimerTick(int timeInterval)
    {
        while (true)
        {
            yield return new WaitForSeconds(timeInterval);
            EventSystem.timeTick(timeInterval);
        }
    }
}

