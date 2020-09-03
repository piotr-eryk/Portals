using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orb : MonoBehaviour
{
    public float speed = 100f;
    void Start()
    {
        
    }
    void Update()
    {
        transform.RotateAround(transform.position, Vector3.right, speed * Time.deltaTime);
        transform.RotateAround(transform.position, Vector3.up, speed * Time.deltaTime);
        transform.RotateAround(transform.position, Vector3.forward, speed * Time.deltaTime);
    }
}
