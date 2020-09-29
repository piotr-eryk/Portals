using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Mirror : ReflectingObject
{
 
    public float speed = 3f;

    public Vector3 targetRotate;

    private Vector3 targetAngle;
    private Vector3 currentAngle;
    private LineRenderer laser;

    public Laser laserScript;
    public GunButton gunButtonScript;
    void Start()
    {
        currentAngle = transform.eulerAngles;
        laser = GetComponent<LineRenderer>();
    }

    // Update is called once per framez
    void Update()
    {
        currentAngle = new Vector3(
        Mathf.LerpAngle(currentAngle.x, targetAngle.x, Time.deltaTime * speed),
        Mathf.LerpAngle(currentAngle.y, targetAngle.y, Time.deltaTime * speed),
        Mathf.LerpAngle(currentAngle.z, targetAngle.z, Time.deltaTime * speed));

        transform.eulerAngles = currentAngle;
    }

    public override void OnTrigger()
    {
        base.OnTrigger();

        targetAngle = targetRotate;
    }

    public override void OnUnTrigger()
    {
        base.OnUnTrigger();

        targetAngle = Vector3.zero;
    }
    public override void OnReflect()
    {
        base.OnReflect();

        laser.SetPosition(0, transform.position);
        laser.transform.Rotate(0.0f, -90.0f, 0.0f);

        if (Physics.Raycast(transform.position, transform.forward, out RaycastHit hit))
        {
            laser.SetPosition(1, hit.point);
           
            if (hit.collider.CompareTag("Player"))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
            else if (hit.collider.CompareTag("BreakableObject"))
            {
                laserScript.OnTouch();
            }
            else if (hit.collider.CompareTag("GunButton"))
            {
                gunButtonScript.pressed = true;
            }
        }
        else laser.SetPosition(1, transform.position + (transform.forward * 5000));

    }
}
