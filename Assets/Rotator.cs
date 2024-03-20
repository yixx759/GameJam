using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    private Transform PLR;

    [SerializeField] private float YrangeS;
    [SerializeField] private float YrangeE;

    private Quaternion down;

    private Quaternion upright;
    // Start is called before the first frame update
    void Start()
    {
        PLR = Mov.Player;
        upright = Quaternion.Euler(Vector3.zero);
        down = Quaternion.Euler(90, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {

        float rotatorT =Mathf.Clamp01( Mathf.InverseLerp(transform.position.y+ YrangeE, transform.position.y + YrangeS, Mov.Player.position.y));

        PLR.rotation = Quaternion.Slerp(upright, down, rotatorT*rotatorT*rotatorT);

      

    }
}
