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

    private Quaternion upright;
    private Animator aRef;

    private bool falling = false;
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

        float rotatorT =Mathf.Clamp01( Mathf.InverseLerp(transform.position.y+ YrangeE, transform.position.y + YrangeS, Mov.Player.position.y));

        
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




        // PLR.rotation = Quaternion.Slerp(upright, down, rotatorT*rotatorT*rotatorT);

      

    }
}
