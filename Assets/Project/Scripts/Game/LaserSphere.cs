﻿using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class LaserSphere : TriggableObject
{
    public GameObject model;
    public bool rotateRight = true;
    public float rotateVelocity = 0;
    private float actualRotateVelocity = 0.3f;
    // Start is called before the first frame update
    void Start()
    {
        OnUnTrigger();
    }

    // Update is called once per frame
    void Update()
    {
        model.transform.Rotate(0, actualRotateVelocity, 0, Space.Self);
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