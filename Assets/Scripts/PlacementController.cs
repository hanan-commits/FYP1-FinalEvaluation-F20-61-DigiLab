using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems; 
using UnityEngine.UI;
[RequireComponent(typeof(ARRaycastManager))]
public class PlacementController : MonoBehaviour
{

    [SerializeField]
    private GameObject placedPrefab;

    private GameObject spawnedObject;

    public GameObject PlacedPrefab{
        get{
            return placedPrefab;
        }
        set{
            placedPrefab = value;
        }
    }
    public Text TimerText;
    private float startTime;
    private bool counterActive = false;
    private bool changeObject = false;
    private Vector3 pos;
    private Quaternion rot;
    private Vector3 scaleChange = new Vector3(0f, 0.02f, 0f);

   
    
    private ARRaycastManager arRaycastManager;

    void Awake() {
        arRaycastManager = GetComponent<ARRaycastManager>();
    }

    void Start()
    {
        startTime = Time.time;
        Debug.Log("Started");
    }

    bool TryGetTouchPosition(out Vector2 touchPosition){
        if (Input.touchCount >0){
            touchPosition = Input.GetTouch(0).position;
            return true;
        }
        touchPosition = default;
        return false;
    }


    // Update is called once per frame
    void Update()
    {
        Debug.Log("Updated");
        if(!TryGetTouchPosition(out Vector2 touchPosition))
            return;
        
        if(arRaycastManager.Raycast(touchPosition,hits, TrackableType.PlaneWithinPolygon)){
            var hitPose = hits[0].pose;
            counterActive = true;
            if(spawnedObject == null)
            {
                    spawnedObject = Instantiate(placedPrefab, hitPose.position, hitPose.rotation);
                    pos = hitPose.position;
                    rot = hitPose.rotation;
                    RotateManager.GetInstance().SetPendulum(spawnedObject);  
                    changeObject = true;
            }
            if (counterActive){
                
                //Timer//
                float t = Time.time - startTime;
                string minutes = ((int) t / 60).ToString();
                string seconds = (t % 60).ToString("f2");

                TimerText.text = minutes + ":" +seconds; 
               // scaleChange = new Vector3(0f, 0.02f, 0f);
            }
                    
        }
    }

    public void increaseScaleRope(){
        var btnTransform = spawnedObject.transform;    
        var Rope = btnTransform.GetChild(4).GetChild(0);
        Rope.transform.localScale += scaleChange;
    }

    static List<ARRaycastHit> hits = new List<ARRaycastHit>();
    
}
