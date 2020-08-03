using System.Collections;
using System.Collections.Generic;
using RewindEngine;
using UnityEngine;

public class SimpleRbRewind : Rewindable
{
    
    
    void Start()
    {
        
    } 
    
    void Update()
    {
        base.Update();

        if (rewindState == State.Normal || clock.localTimeScale > 0f)
        {
            GetComponent<Rigidbody>().AddTorque(Vector3.forward * 10f,ForceMode.VelocityChange);
        }
    }
}
