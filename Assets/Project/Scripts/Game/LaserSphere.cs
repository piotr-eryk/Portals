using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class LaserSphere : TriggableObject
{
    public GameObject model;
    public bool rotateRight = true;
    public float rotateVelocity = 0;
    private float actualRotateVelocity = 0.3f;
    void Start()
    {
        OnUnTrigger();
    }
    void Update()
    {
        model.transform.Rotate(0, 0, actualRotateVelocity, Space.Self);
    }

    public override void OnTrigger()
    {
        base.OnTrigger();
        actualRotateVelocity = 0;
    }

    public override void OnUnTrigger()
    {
        base.OnUnTrigger();
        if (rotateRight == true)
        {
            actualRotateVelocity = 1f * rotateVelocity;
        }
        else
        {
            actualRotateVelocity = -1f * rotateVelocity;
        }
    }
}
