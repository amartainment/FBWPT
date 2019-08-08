using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class vineSegmentAnimation : MonoBehaviour
{
    public GameObject leaf1;
    public GameObject leaf2;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void enableLeaves()
    {
        leaf1.SetActive(true);
        leaf2.SetActive(true);
    }
}
