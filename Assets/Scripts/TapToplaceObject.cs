using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

[RequireComponent(typeof(ARRaycastManager))]
public class TapToplaceObject : MonoBehaviour
{

    public GameObject ObjectInstantiate;
    private GameObject SpwanObject;
    private ARRaycastManager arRaycastManager;
    private Vector2 touchPosition;

    static List<ARRaycastHit> hits = new List<ARRaycastHit>();
    private void Awake()
    {
        arRaycastManager = GetComponent<ARRaycastManager>();
    }

    bool tryTouchPosition(out Vector2 touchPosition)
    {
        if (Input.touchCount > 0)
        {
            touchPosition = Input.GetTouch(index: 0).position;
            return true;
        }
        touchPosition = default;
        return false;
    }

    private void Update()
    {
        if (!tryTouchPosition(out Vector2 touchPosition))
            return;
        if(arRaycastManager.Raycast(touchPosition, hits, trackableTypes: TrackableType.PlaneWithinPolygon))
        {
            var hitPos = hits[0].pose;

            if(SpwanObject == null)
            {
                SpwanObject = Instantiate(ObjectInstantiate, hitPos.position, hitPos.rotation);
            }
            else
            {
                SpwanObject.transform.position = hitPos.position;
            }
        }
    }
}
