using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Laser : MonoBehaviour
{
    public BreakableObject targetObject; 

    private LineRenderer laser;

    void Start()
    {
        laser = GetComponent<LineRenderer>();
    }

    void Update()
    {
        laser.SetPosition(0, transform.position);
        
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit))
        {
            laser.SetPosition(1, hit.point);
            if (hit.collider.CompareTag("Player"))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
            else if (hit.collider.CompareTag("BreakableObject"))
            {
                OnTouch();
            }
        }
        else laser.SetPosition(1, transform.position + (transform.forward * 5000));
       
    }

    private void OnTouch()
    {
        targetObject.OnTouch();

        // tutaj będzie zmiana koloru czy czegoś lasera
    }
    private void OnUntouch()
    {
        targetObject.OnUntouch();

        // tutaj będzie zmiana koloru czy czegoś lasera
    }
}
