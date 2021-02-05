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
    }

    private void OnReflect()
    {
        targetReflectingObject.OnReflect();
    }
    public void ShootLaser()
    {
        laser.SetPosition(0, transform.position);

        if (Physics.Raycast(transform.position, transform.forward, out RaycastHit hit))
        {
            laser.SetPosition(1, hit.point);

            switch (hit.collider.tag)
            {
                case "Player":
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
                    break;
                case "Mirror":
                OnReflect();
                    break;
                case "BreakableObject":
                OnTouch();
                    break;
            }

        }
        else laser.SetPosition(1, transform.position + (transform.forward * 5000));

    }
}
