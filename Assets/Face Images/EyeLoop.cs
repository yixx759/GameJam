using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EyeLoop : MonoBehaviour
{
    [SerializeField] private  float eyeshuffle = 0.2f;
    [SerializeField] private Texture[] imgs;
    [SerializeField] private Texture[] BlinkImages;
    private int counter;
    private int counterL;
    private int counterBlink = 0;
    private float t = 0;
    private float bt = 0;
    private float btt = 0;
    private Material eyeMat;
    private bool blinking = false;
    [SerializeField] private float BlinkingInterval;
    [SerializeField] private float BlinkingFrameInterval = 2.5f;
    
    // Start is called before the first frame update
    void Start()
    {
        eyeMat = this.GetComponent<Renderer>().material;
        counterL = imgs.Length;
    }

    // Update is called once per frame
    void Update()
    {
        if (!blinking)
        {
            
            
            t += Time.deltaTime;

            if (t > eyeshuffle)
            {
                t = 0;
           
                eyeMat.SetTexture("_MainTex", imgs[(counter++)%counterL]);
//                print((counter) % counterL);

            }

            bt += Time.deltaTime;

            if (bt >BlinkingInterval)
            {
                blinking = true;
                
            }
            //do blink

        }
        else
        {
            btt += Time.deltaTime;
            if (btt > BlinkingFrameInterval)
            {
                eyeMat.SetTexture("_MainTex", BlinkImages[counterBlink++]);

                btt = 0;


            }

            
            if (counterBlink >= BlinkImages.Length)
            {
                blinking = false;
                bt = 0;
                btt = 0;
                counterBlink = 0;

            }

        }


    }
}
