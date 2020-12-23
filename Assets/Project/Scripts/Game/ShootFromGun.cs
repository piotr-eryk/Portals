using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootFromGun : MonoBehaviour
{
    public float bulletSpeed = 4f;
    public GameObject bulletPrefab;
    public float shootDelay = 1.0f;

    private float elapsed = 0f;

    void Update()
    {
        elapsed += Time.deltaTime;
        if (elapsed > shootDelay)
        {
            elapsed = 0.0f;
            SpawnBullet();
        }
    }
    private void SpawnBullet()
    {
        GameObject bulletObject = Instantiate(bulletPrefab);
        Destroy(bulletObject.gameObject, 5);
        bulletObject.transform.position = transform.position + transform.forward*2f;

        bulletObject.transform.rotation = transform.rotation;
        bulletObject.transform.Rotate(90.0f, 0.0f, 0.0f, Space.Self);

        Rigidbody rigidbody = bulletObject.GetComponent<Rigidbody>();
        rigidbody.velocity = transform.forward * bulletSpeed;
    }
}
