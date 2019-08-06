using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeManager : MonoBehaviour
{
    public float timeInterval;
    public float timer;
    public float timeCounter;
    public Text textElement;

    void Start()
    {
        timer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime/ timeInterval;
        timeCounter = Mathf.Round(timer);
        textElement.text = timeCounter.ToString();
    }
}
