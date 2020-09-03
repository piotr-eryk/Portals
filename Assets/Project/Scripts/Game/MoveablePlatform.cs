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
   // public GameObject player;

    private Vector3 targetPosition;
    //  private Vector3 startPosition;
    private bool pressed = false;
    void Start()
    {
        //     startPosition = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        targetPosition = Vector3.zero;
    }

    // Update is called once per frame
    private void Update()
    {
        
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
