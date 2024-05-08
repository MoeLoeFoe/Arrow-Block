using System.Collections;
using System.Collections.Generic;
using UnityEditor.U2D.IK;
using UnityEngine;
using UnityEngine.UI;


public class InkBar : MonoBehaviour
{
    public float ink;
    [SerializeField]private float maxInk; 
    private UnityEngine.UI.Slider inkBar;
    [SerializeField] private float dValue;
    [SerializeField] private LineDraw linedrawScript;
    public static bool alrdyloaded;
    private Animator sliderAnim;

    
    
    void Start()
    {
        
        inkBar = GameObject.FindObjectOfType<UnityEngine.UI.Slider>();
        ink = inkBar.value;
        inkBar.maxValue = maxInk;
        sliderAnim=inkBar.GetComponent<Animator>();

    }
    private void turnLoadingOff()
    {
       
        LineDraw.loading = false;
        alrdyloaded = false;
        
    }
    void Update()
    {
        if (!LineDraw.loading)
        {
            if (linedrawScript.drawing)
            {
                DecreaseInk();
                
            }
            else if (ink != maxInk)
            {
                IncreaseInk();
            }
            inkBar.value = ink;
        }
        if (inkBar.value == 0 && !alrdyloaded)
        {
            sliderAnim.SetTrigger("flash");
            LineDraw.loading = true;
            alrdyloaded = true;
            Invoke("turnLoadingOff", 1f);
        }
       
        if(alrdyloaded && !LineDraw.loading)
        {
            alrdyloaded = false;
        }

    }
    private void DecreaseInk()
    {
        
        if (ink > 0)
        {
            ink-=(1*dValue)*Time.deltaTime;
        }
        
    }
    private void IncreaseInk()
    {
        
       ink += (dValue/2) * Time.deltaTime;
        
    }

}
