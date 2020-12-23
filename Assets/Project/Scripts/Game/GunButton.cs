using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunButton : MonoBehaviour
{
    public TriggableObject targetObject;

    public GameObject model;
    public float pressureHeight = -1.6f;
    public float pressedSpeed = 3f;
    public bool pressed;

    private Vector3 targetPosition;
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
    void OnTriggerEnter(Collider otherCollider)
    {
        if (otherCollider.gameObject.CompareTag("Projectile"))
        {
            pressed = true;
        }
    }

    private void OnPress()
    {
        targetObject.OnTrigger();
    }
}
