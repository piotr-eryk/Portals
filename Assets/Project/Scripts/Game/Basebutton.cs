using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Basebutton : MonoBehaviour
{
    public TriggableObject targetObject;

    public GameObject model;
    public float pressureHeight = -1.6f;
    public float pressedSpeed = 3f;
    public bool pressed; //zmienić na protected po ogarnięciu skryptu lustra

    protected Vector3 targetPosition;
    void Start()
    {
        targetPosition = Vector3.zero;
    }
    void Update()
    {
        if (pressed == true)
        {
            targetPosition = new Vector3(0, 0, pressureHeight);
            OnPress();
        }
        model.transform.localPosition = Vector3.Lerp(model.transform.localPosition, targetPosition, Time.deltaTime * pressedSpeed);
    }

    protected void OnPress()
    {
        targetObject.OnTrigger();
    }
}
