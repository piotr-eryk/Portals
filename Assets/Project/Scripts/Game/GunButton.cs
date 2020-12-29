using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GunButton : Basebutton
{
    void OnTriggerEnter(Collider otherCollider)
    {
        if (otherCollider.gameObject.CompareTag("Projectile"))
        {
            pressed = true;
        }
    }
}
