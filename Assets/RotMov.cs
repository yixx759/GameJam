using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotMov : MonoBehaviour
{
    public Rotator[] R;
    private static int  counter = 0;
    public static bool switching;
    
    
    // Start is called before the first frame update
    void OnEnable()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        switching = true;
        R[counter].enabled = false;
        R[++counter].enabled = true;


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
