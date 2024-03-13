using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mov : MonoBehaviour
{

    [SerializeField] private float speed;
    [SerializeField] private float Changespeed;
    [SerializeField] private float FallSpeed;
    private Vector3 Desired;
    

    private Rigidbody r;
    // Start is called before the first frame update
    void Start()
    {
        r = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 D = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));



        Desired = new Vector3(D.normalized.x, 0, D.normalized.y)*speed;






    }

    private void FixedUpdate()
    {

        Vector3 vel = r.velocity;


        vel = new Vector3(Mathf.MoveTowards(vel.x, Desired.x, Changespeed * Time.deltaTime), Mathf.Clamp(vel.y,-FallSpeed,FallSpeed),
            Mathf.MoveTowards(vel.z, Desired.z, Changespeed * Time.deltaTime));


        r.velocity = vel;





    }
}
