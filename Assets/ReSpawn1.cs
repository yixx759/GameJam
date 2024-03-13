using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReSpawn1 : MonoBehaviour
{
    public  Vector3 Respawn_point = Vector3.zero;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.collider.CompareTag("Respawn"))
        {
            transform.position = Respawn_point;

        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
