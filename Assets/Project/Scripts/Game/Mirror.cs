using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mirror : TriggableObject
{

    public float speed = 3f;
    public bool rotateLeft = true;
    public float rotateAngle = 45f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.localRotation = Vector3.Lerp(transform.localRotation, rotateAngle, Time.deltaTime * speed);
    }

    public override void OnTrigger()
    {
        base.OnTrigger();

        targetPosition = new Vector3(0, openedHeight, 0);
    }

    //public override void OnUnTrigger()
    //{
    //    base.OnUnTrigger();

    //    targetPosition = Vector3.zero;
    //}
}
