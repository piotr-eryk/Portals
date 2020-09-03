using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour
{
    public Transform target;
    public List<GameObject> panels;

    private readonly float lockPos = 0;
    private float scriptDelay;

    IEnumerator Start()
    {
        scriptDelay = GameObject.Find("Gun").GetComponent<ShootFromGun>().shootDelay;

        while (true)
        {
            yield return StartCoroutine(LightPanel());  //jest lekka desynchronizacja po paru strzałach
            yield return StartCoroutine(PutPanel());
        }
    }

    void Update()
    {
        if (target != null)
        {
            transform.LookAt(target);
            transform.rotation = Quaternion.Euler(lockPos, transform.rotation.eulerAngles.y, lockPos);
        }
    }
    private IEnumerator LightPanel()
    {

        WaitForSeconds wait = new WaitForSeconds(scriptDelay / panels.Count);
        foreach (GameObject panel in panels)
        {
            yield return wait;
            panel.GetComponent<Renderer>().material.color = Color.green;
        }
    }
    private IEnumerator PutPanel()
    {
        foreach (GameObject panel in panels)
        {
            panel.GetComponent<Renderer>().material.color = Color.red;
            yield return null;
        }
    }
}
