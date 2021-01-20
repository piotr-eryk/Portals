using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private GrabbableObject grabbableObject;

    [Header("Portals")]
    public GameObject portalPrefab;
    public RenderTexture[] renderTextures;

    [Header("Grabbable Objects")]
    public float grabbingDistance = 2f;
    public float throwingForce = 4f;

    private List<Portal> portals;
    private bool shouldUseFirstPortal = true;

    public Action OnCollectOrb;

    private Camera playerCamera;
    void Start()
    {
        portals = new List<Portal>();
        playerCamera = transform.GetComponentInChildren<Camera>();
    }

    void Update()
    {
        bool interactedWithObject = false;

        if (Input.GetMouseButtonUp(0))
        {
            if (grabbableObject != null)
            {
                Release();
                interactedWithObject = true;
            }
            else
            {
                if (Physics.Raycast(transform.position, playerCamera.transform.forward, out RaycastHit hit, grabbingDistance))
                {
                    if (hit.transform.GetComponent<GrabbableObject>() != null)
                    {
                        GrabbableObject targetObject = hit.transform.GetComponent<GrabbableObject>();
                        if (grabbableObject == null)
                        {
                            Hold(targetObject);
                            interactedWithObject = true;
                        }
                    }
                }
            }
        }

        if (Input.GetMouseButtonUp(0) && interactedWithObject == false)
        {
            if (Physics.Raycast(playerCamera.transform.position, playerCamera.transform.forward, out RaycastHit hit))
            {
                if (hit.transform.GetComponent<PortalArea>() != null)
                {
                    Vector3 spawnPoint = hit.point;
                    SpawnPortal(hit.point, hit.normal, hit.transform.GetComponent<PortalArea>());


                }
            }
        }
        if (grabbableObject != null)
        {
            grabbableObject.transform.position = playerCamera.transform.position + playerCamera.transform.forward * grabbingDistance;
        }
    }

    private void Hold (GrabbableObject targetObject)
    {
        grabbableObject = targetObject;
        grabbableObject.GetComponent<Collider>().enabled = false;
        grabbableObject.GetComponent<Rigidbody>().useGravity = false; 
    }

    private void Release()
    {
        grabbableObject.GetComponent<Collider>().enabled = true;
        grabbableObject.GetComponent<Rigidbody>().useGravity = true;
        grabbableObject.GetComponent<Rigidbody>().AddForce(playerCamera.transform.forward * throwingForce);
        grabbableObject = null;
    }

    void OnTriggerEnter(Collider otherCollider)
    {
        if (otherCollider.GetComponent<Orb> () != null)
        {
            OnCollectOrb?.Invoke();
        }
        if (otherCollider.GetComponent<Portal> () != null)
        {
            Portal enterPortal = otherCollider.GetComponent<Portal>();
            Portal exitPortal = enterPortal == portals[0] ? portals[1] : portals[0];

            gameObject.GetComponent<CharacterController>().enabled = false;
            
            transform.position = exitPortal.transform.position + exitPortal.transform.forward;
            transform.forward = exitPortal.transform.forward;
            transform.GetComponent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController>().CopyRotation (exitPortal.transform);
            
            gameObject.GetComponent<CharacterController>().enabled = true; 
        }
    }

#pragma warning disable IDE0060 // Usuń nieużywany parametr
    private void SpawnPortal(Vector3 spawnPoint, Vector3 normal, PortalArea area)
#pragma warning restore IDE0060 // Usuń nieużywany parametr
    {
        Portal currentPortal;

        if (portals.Count < 2)
        {
            GameObject portalObject = Instantiate(portalPrefab);
            currentPortal = portalObject.GetComponent<Portal>();
            currentPortal.GetComponentInChildren<Camera>().enabled = false;
            portals.Add(currentPortal);

            if (portals.Count == 2)
            {
                portals[0].GetComponentInChildren<Camera>().enabled = true;
                portals[1].GetComponentInChildren<Camera>().enabled = true;
                portals[0].GetComponentInChildren<Camera>().targetTexture = renderTextures[0];
                portals[1].GetComponentInChildren<Camera>().targetTexture = renderTextures[1];
                portals[0].GetComponent<Renderer>().material.SetTexture("_MainTex", renderTextures[1]);
                portals[1].GetComponent<Renderer>().material.SetTexture("_MainTex", renderTextures[0]);
            }
        }
        else
        {
            currentPortal = portals[shouldUseFirstPortal ? 0 : 1];
            shouldUseFirstPortal =! shouldUseFirstPortal;
        }
        currentPortal.transform.position = spawnPoint;
        currentPortal.transform.forward = normal;
    }
}
