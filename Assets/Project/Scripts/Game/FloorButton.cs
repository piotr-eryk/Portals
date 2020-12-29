using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;


public class FloorButton : Basebutton
{
    void OnTriggerStay(Collider otherCollider)
    {
        if (otherCollider.GetComponent<Player>() != null || otherCollider.GetComponent<GrabbableObject>() != null)
        {
            pressed = true;
        }
    }
}
