using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveablePlatform : MonoBehaviour
{
    public float xTravelDistance = 0f;
    public float yTravelDistance = 0f;
    public float zTravelDistance = 0f;
    public float flightSpeed = 0.5f;
    public GameObject model;

    private Vector3 targetPosition;
    private bool pressed = false;
    void Start()
    {
        targetPosition = Vector3.zero;
    }
    private void FixedUpdate()
    {
        if (pressed == true)
        {
            targetPosition = new Vector3(xTravelDistance, yTravelDistance, zTravelDistance);
        }
        else
        {
            targetPosition = Vector3.zero;
        }
        model.transform.localPosition = Vector3.Lerp(model.transform.localPosition, targetPosition, Time.deltaTime * flightSpeed);
    }

    void OnTriggerEnter(Collider otherCollider)
    {
        if (otherCollider.GetComponent<Player>() != null)
        {
            otherCollider.transform.parent = transform;
            pressed = true;
        }
    }

    void OnTriggerExit(Collider otherCollider)
    {
        if (otherCollider.GetComponent<Player>() != null)
        {
            otherCollider.transform.parent = null;
            pressed = false;
        }
    }
}
