using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class BreakableWall : BreakableObject
{
    public GameObject model;
    public float durationDestroy = 3f; 

    private Color lerpingColor;
    private Color originalColor = Color.white;
    private float t = 0f;
    void Update()
    {
        if (model)
        {
            model.GetComponent<Renderer>().material.color = Color.Lerp(originalColor, lerpingColor, t);
            if (model.GetComponent<Renderer>().material.color == Color.red)
            {
                Destroy(model);
            }
        }
    }
    public override void OnTouch()
    {
        t += Time.deltaTime / durationDestroy;
        base.OnTouch();
        Color originalColor = model.GetComponent<Renderer>().material.color;
        lerpingColor = Color.red;
    }

    public override void OnUntouch()
    {
        base.OnUntouch();
        if (model) 
        {
            t -= Time.deltaTime / durationDestroy;
            Color originalColor = model.GetComponent<Renderer>().material.color;
            lerpingColor = Color.white;
        }
    }
}
