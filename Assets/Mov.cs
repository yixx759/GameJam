using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



struct Rotaions
{
    public float CosX;
    public float SinX;
    public float CosY;
    public float SinY;

}


public class Mov : MonoBehaviour
{

    [SerializeField] private float speed;
    [SerializeField] private float Changespeed;
    [SerializeField] private float FallSpeed;
    [SerializeField] private float WalkThreshold;
    [SerializeField] private float SpeedIncreaseT;
    private Vector3 Desired;
    [SerializeField]private Transform Cam;
    [SerializeField]private float camspeedx;
    [SerializeField]private float camspeedy;
    [SerializeField]private float radius;
    [SerializeField]private float FixedCamYOffset;
    [SerializeField]private bool FixedCam;
    public static Transform Player;
    private Animator aRef;
    private const float hpi = Mathf.PI / 2;
    private float Camx = 0;
    private float Camy = 0;


    private Rigidbody r;

    private bool onGround = false;
    // Start is called before the first frame update
    private void OnEnable()
    {
        Player = this.transform;
        
    }

    void Start()
    {
     
        aRef = GetComponent<Animator>();
        r = GetComponent<Rigidbody>();
        Camx = -Mathf.PI/2 + 0.1f;
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.GetContact(0).normal.y >0.9f)
        {
            onGround = true;

        }
    }
    
    private void OnCollisionExit(Collision other)
    {
        // if (other.GetContact(0).normal.y >0.9f)
        // {
        //     onGround = false;
        //
        // }
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 dynamicCam;
        Vector3 staticCam;
        Vector2 D = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));


        //cache this
        Vector3 c = new Vector3(0,GetComponent<CapsuleCollider>().bounds.extents.y,0);

        Desired = new Vector3(D.normalized.x, 0, D.normalized.y)*speed;
        //copy before rotating maybe or rotate after use

        float tocheck = Camy - Input.GetAxis("Mouse Y") * camspeedy;
        float tocheck1 = Camx - Input.GetAxis("Mouse X")*camspeedx;
       
        if (tocheck <= hpi-hpi/4 && tocheck > 0)
        {
         
            Camy = tocheck; 
            
        }
        
        if (tocheck1 >= -Mathf.PI && tocheck1 < 0)
        {
         
            Camx = tocheck1; 
            
        }

        //Maybe if this away when not neede if less expensive than breaking pipeline
        
        Rotaions rots;
        rots = new Rotaions()
            { CosX = Mathf.Cos(Camx), CosY = Mathf.Cos(Camy), SinX = Mathf.Sin(Camx), SinY = Mathf.Sin(Camy) };
        float time = Time.deltaTime;
        dynamicCam = (transform.position +c)+
                       (new Vector3(rots.CosX * rots.CosY, rots.SinY,
                           rots.SinX * rots.CosY ) * radius);
            staticCam = transform.position + new Vector3(0, FixedCamYOffset, 0);
            Cam.transform.position = Vector3.Lerp(dynamicCam, staticCam, Rotator.CamInterpo * Rotator.CamInterpo* Rotator.CamInterpo);

    
        Cam.rotation = Quaternion.LookRotation((transform.position + c) - Cam.position, Vector3.up);

    }

    private void FixedUpdate()
    {

        Vector3 vel = r.velocity;


        vel = new Vector3(Mathf.MoveTowards(vel.x, Desired.x, Changespeed * Time.deltaTime), Mathf.Clamp(vel.y,-FallSpeed,FallSpeed),
            Mathf.MoveTowards(vel.z, Desired.z, Changespeed * Time.deltaTime));


        r.velocity = vel;

        
        
        //change to not desired but dot product with acc velocity later
        
        
        
        
        
        
        
        //rotate with camera
        //find school
        //do soem cut scenes
        //fix respawn
        //have animation complete by ground have speed be 1 until floor
        
        
        
        Vector2 movq = new Vector2(r.velocity.x, r.velocity.z);

        float t = Mathf.Clamp01(Mathf.InverseLerp(0, SpeedIncreaseT, movq.magnitude));

        //aRef.speed = t;
        aRef.speed = !Rotator.falling ? t : 1;
//        print(t);
        if (movq.magnitude > WalkThreshold && !Rotator.falling)
        {
        //    print(Desired);
            if (Desired.z <= 0.01f && Desired.z >= -0.01f )
            {
                
                aRef.SetBool("Walking",false );
                if (Desired.x > 0.1f)
                {
                   // print("bong");
                    aRef.SetBool("Right",true );
                    aRef.SetBool("Left",false );
                    
                    
                }
                else if(Desired.x < -0.1f)
                {
//                    print("bing");
                    aRef.SetBool("Right",false );
                    aRef.SetBool("Left",true );
                    
                    
                }
                else
                {
                    
                    aRef.SetBool("Right",false );
                    aRef.SetBool("Left",false );
                    
                }

            }
            else
            {
              //  print("walking");
                aRef.SetBool("Walking",true );
                aRef.SetBool("Right",false );
                aRef.SetBool("Left",false );
              
               


            }

           
        }
        else
        {
            aRef.SetBool("Walking",false );
            aRef.SetBool("Right",false );
            aRef.SetBool("Left",false );
        }



        
        



    }
}
