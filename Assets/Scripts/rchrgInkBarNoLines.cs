using Newtonsoft.Json.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class rchrgInkBarNoLines : MonoBehaviour
{
    private UnityEngine.UI.Slider slider;
    private float ink;
    [SerializeField] private float dValue;
    void Start()
    {
        slider = GameObject.FindObjectOfType<UnityEngine.UI.Slider>();
        ink = slider.value;
        
    }

  
    void Update()
    {
        ink = slider.value;
        if (GameObject.FindGameObjectWithTag("drawnwall") == null)
        {
            ink += (dValue / 2) * Time.deltaTime;
            slider.value = ink;
        }
        else
        {
            this.gameObject.SetActive(false);
        }

        if (LineDraw.loading && slider.value > 0)
        {
            LineDraw.loading = false;
        }
    }
}
