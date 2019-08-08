using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animatorEventCalls : MonoBehaviour
{
    public WheezingPlantBehavior myMaster;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void triggerMasterGasRelease()
    {
        myMaster.releaseGas();
    }
}
