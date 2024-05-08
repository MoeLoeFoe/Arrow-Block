using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiaScript : MonoBehaviour
{
    public BillyMovement billyref;
   public void CallTurnIsOpenOff()
    {
        billyref.TurnIsOpenOff();
    }
    public void CallturnDiaTextOn()
    {
        billyref.turnDiaTextOn();
    }
}
