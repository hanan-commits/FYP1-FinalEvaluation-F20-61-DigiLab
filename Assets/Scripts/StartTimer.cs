using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class StartTimer : MonoBehaviour
{
    // Start is called before the first frame update
    public Text TimerText;
    private float startTime;
    private bool counterActive = false;
    void Start()
    {
        startTime = Time.time;
    }

    // Update is called once per frame
    public void Update()
    {
        if(Input.GetMouseButtonDown(0)){
            counterActive = true;
           
        }
        if (counterActive){
            float t = Time.time - startTime;
            string minutes = ((int) t / 60).ToString();
            string seconds = (t % 60).ToString("f2");

            TimerText.text = minutes + ":" + seconds; 
        }
      
    }
}
