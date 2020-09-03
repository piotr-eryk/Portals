using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class FloorButton : MonoBehaviour
{
    public TriggableObject targetObject;

    public GameObject model;
    public float pressureHeight = -1.6f;
    public float pressedSpeed = 3f;
    private bool pressed;

    private Vector3 targetPosition;
    // Start is called before the first frame update
    void Start()
    {
        targetPosition = Vector3.zero;
    }

    // Update is called once per frame
    void Update()
    {
        if (pressed == true)
        {
            targetPosition = new Vector3(0, pressureHeight, 0);
            OnPress();
        }
        model.transform.localPosition = Vector3.Lerp(model.transform.localPosition, targetPosition, Time.deltaTime * pressedSpeed);
    }
    //otherCollider to rzecz, która załączy OnTriggerStay (np Box)
    void OnTriggerStay(Collider otherCollider)
    {
        if (otherCollider.GetComponent<Player>() != null || otherCollider.GetComponent<GrabbableObject>() != null)
        {
            pressed = true;
        }
    }

    private void OnPress()
    {
        targetObject.OnTrigger();
    }
}
