using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : TriggableObject
{

    public GameObject doorTop;
    public GameObject doorBot;
    public float speed = 3f;
    public float openedHeightTop;
    public float openedHeightBot;

    private Vector3 targetPositionTop;
    private Vector3 targetPositionBot;
    void Start()
    {
        targetPositionTop = Vector3.zero;
        targetPositionBot = Vector3.zero;
    }

    void Update()
    {
        doorTop.transform.localPosition = Vector3.Lerp(doorTop.transform.localPosition, targetPositionTop, Time.deltaTime * speed);
        doorBot.transform.localPosition = Vector3.Lerp(doorBot.transform.localPosition, targetPositionBot, Time.deltaTime * speed);
    }

    public override void OnTrigger()
    {
        base.OnTrigger();

        targetPositionTop = new Vector3(0, openedHeightTop, 0);
        targetPositionBot = new Vector3(0, openedHeightBot, 0);
    }

    public override void OnUnTrigger()
    {
        base.OnUnTrigger();

        targetPositionTop = Vector3.zero;
        targetPositionBot = Vector3.zero;
    }
}
