using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeinScript : MonoBehaviour
{
    [SerializeField] private GameObject sceneChanger;
    private Animator anim;
    void Start()
    {
        anim=sceneChanger.GetComponent<Animator>();
        anim.SetTrigger("FadeIn");
    }

   
}
