using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class PlaceOnPlane : MonoBehaviour
{
    ARRaycastManager ARRaycastManager;
    private Vector2 _touchPosition;
    private PlaceOnPlane _placeOnPlane;
   

    public GameObject ScenePrefab;

    static List<ARRaycastHit> Hits = new List<ARRaycastHit>();

    private void Awake()
    {
        ARRaycastManager = GetComponent<ARRaycastManager>();
        _placeOnPlane = GetComponent<PlaceOnPlane>();
        
        ScenePrefab.SetActive(false);
    }

    private void Update()
    {
        if (Input.touchCount>0&& Input.touches[0].phase == TouchPhase.Began)
        {
            _touchPosition = Input.GetTouch(0).position;

            if (ARRaycastManager.Raycast(_touchPosition, Hits, TrackableType.PlaneWithinPolygon))
            {
                var hitPose = Hits[0].pose;

                ScenePrefab.SetActive(true);
                ScenePrefab.transform.position = hitPose.position;
                LookAtPlayer(ScenePrefab.transform);
            }
        }
        if(Input.touches[0].phase == TouchPhase.Ended)
        {
            ARRaycastManager.enabled = false;
            _placeOnPlane.enabled = false;
        }
    }

    void LookAtPlayer(Transform scene)
    {
        var LookDirection = Camera.main.transform.position - scene.position;
        LookDirection.y = 0;
        scene.rotation = Quaternion.LookRotation(LookDirection);
    }
}
