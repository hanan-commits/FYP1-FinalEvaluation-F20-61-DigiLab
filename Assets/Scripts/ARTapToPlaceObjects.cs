using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems; 
using UnityEngine.UI;

[RequireComponent(typeof(ARRaycastManager))]

public class ARTapToPlaceObjects : MonoBehaviour
{
     public GameObject gameObjectToInstantiate;

     private GameObject spawnedObject;
     private ARRaycastManager _arRaycastManager;
     private Vector2 touchPosition;
     public Canvas canvas;

     static List<ARRaycastHit> hits = new List<ARRaycastHit>();

     private void Awake()
     {
          _arRaycastManager = GetComponent<ARRaycastManager>();
     }

     bool TryGetTouchPosition(out Vector2 touchPosition)
     {
          if(Input.touchCount > 0)
          {
               touchPosition = Input.GetTouch(0).position;
               return true;
          }
          touchPosition = default;
          return false;
     }
     void Update()
     {
          if(!TryGetTouchPosition(out Vector2 touchPosition))
          {
               return;
          }
          if (_arRaycastManager.Raycast(touchPosition, hits, TrackableType.PlaneWithinPolygon))
          {
               var hitPose = hits[0].pose;

               if(spawnedObject == null)
               {
                    spawnedObject = Instantiate(gameObjectToInstantiate, hitPose.position, hitPose.rotation);
                    canvas.gameObject.SetActive(true);
               }
               else
               {
                    spawnedObject.transform.position = hitPose.position;
                    canvas.gameObject.SetActive(false);
               }
          }
     }
}
