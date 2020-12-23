using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformGun : MonoBehaviour
{
    [Header("Platform Size")]
    public GameObject platformPrefab;
    public float xSize = 0.1f;
    public float ySize = 0.1f;
    public float zSize = 0.1f;

    [Header("Platform Lifetime")]
    public float platformDelay = 1.0f;
    public float lifetime = 3.0f;

    private float elapsed = 0f;

    void Update()
    {
        elapsed += Time.deltaTime;
        if (elapsed > platformDelay)
        {
            elapsed = 0.0f;
            SpawnPlatform();
        }
    }

    private void SpawnPlatform()
    {
        GameObject platformObject = Instantiate(platformPrefab);
        platformObject.transform.rotation = transform.rotation;
        platformObject.transform.Rotate(0.0f, 0.0f, 90.0f, Space.Self);

        platformObject.transform.localScale = new Vector3(xSize, ySize, zSize);
        platformObject.transform.position = transform.localPosition + transform.forward * platformObject.GetComponent<Renderer>().bounds.size.z/2;

        Destroy(platformObject.gameObject, lifetime);
    }
}
