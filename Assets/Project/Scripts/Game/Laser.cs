using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Laser : MonoBehaviour
{
    public BreakableObject targetObject;

    public ReflectingObject targetReflectingObject;

    private LineRenderer laser;

    void Start()
    {
        laser = GetComponent<LineRenderer>();
    }

    void Update()
    {
        ShootLaser();
    }
    public void OnTouch()
    {
        targetObject.OnTouch();

        // tutaj będzie zmiana koloru czy czegoś lasera
    }
    //private void OnUntouch()
    //{
    //    targetObject.OnUntouch();

    //    // tutaj będzie zmiana koloru czy czegoś lasera
    //}

    private void OnReflect()
    {
        targetReflectingObject.OnReflect();

        // tutaj będzie zmiana koloru czy czegoś lasera
    }

    public void ShootLaser()
    {
        laser.SetPosition(0, transform.position);

        if (Physics.Raycast(transform.position, transform.forward, out RaycastHit hit))
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
            else if (hit.collider.CompareTag("Mirror"))
            {
                OnReflect();
            }
        }
        else laser.SetPosition(1, transform.position + (transform.forward * 5000));

    }
}
