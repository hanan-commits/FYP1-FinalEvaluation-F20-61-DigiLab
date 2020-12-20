using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Lean.Touch;

public class RotateManager : MonoBehaviour
{
    private static RotateManager instance;
    private GameObject _pendulum;

    public static RotateManager GetInstance(){
        return instance;
    }
    private void Awake() {
        instance = this;
    }
    public void SetPendulum(GameObject pendulum){
        _pendulum = pendulum;
    }
    public void SetYaxis(){
        var rotate = _pendulum.GetComponent<LeanTwistRotateAxis>();
        rotate.Axis.x = 0;
        rotate.Axis.y = -1;
        rotate.Axis.z = 0;
    }
}
