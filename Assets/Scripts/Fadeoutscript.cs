using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fadeoutscript : MonoBehaviour
{
    [SerializeField] private HomeGameManager gameManager;
    void Start()
    {
        
    }

    public void callPlayFromManager()
    {
        gameManager.GoPlay();
    }
}
