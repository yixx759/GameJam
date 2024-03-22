using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    private Transform PLR;

    [SerializeField] private float YrangeS;
    [SerializeField] private float YrangeE;

    private Quaternion down;
    public static float CamInterpo = 0;

    private Quaternion upright;
    private Animator aRef;
    private float swapTimer = 0;
   private static float swapTimerLim = 2.4f;

    public static bool falling = false;
    // Start is called before the first frame update
    void Start()
    {
        
        aRef = Mov.Player.gameObject.GetComponent<Animator>();
        PLR = Mov.Player;
        upright = Quaternion.Euler(Vector3.zero);
        down = Quaternion.Euler(90, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {

        if (!RotMov.switching)
        {
            
            float rotatorT =Mathf.Clamp01( Mathf.InverseLerp(transform.position.y+ YrangeE, transform.position.y + YrangeS, Mov.Player.position.y));

            CamInterpo = rotatorT;
            if (rotatorT > 0.7f)
            {
                //change names of var
                if (!falling)
                {
                    falling = true;
                    aRef.SetBool("Falling", true);
                    aRef.Play("a", 1 );

                
                }

            
            
            }
            else
            {
                if (falling)
                {
                    falling = false;
                    aRef.SetBool("Falling", false);
                    aRef.Play("def", 1 );
                
                }

            
            }

            swapTimer = 0;



        }
        else
        {

            falling = true;
            aRef.SetBool("Falling", true);   
            
            aRef.SetBool("Walking",false );
            aRef.SetBool("Right",false );
            aRef.SetBool("Left",false );
            swapTimer += Time.deltaTime;
            
            CamInterpo = Mathf.InverseLerp(0,swapTimerLim,swapTimer);
            print(CamInterpo);
            if(swapTimer > swapTimerLim) { RotMov.switching = false;}

        }
        
            
        






        // PLR.rotation = Quaternion.Slerp(upright, down, rotatorT*rotatorT*rotatorT);

      

    }
}
