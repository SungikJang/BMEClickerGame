using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Laptime : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private Text timeText;
    private float LapTime = 0;
    private bool startLapTime = false;
    private int Minute = 0;

    public bool StartLapTime
    {
        get
        {
            return startLapTime;
        }
        set
        {
            if (startLapTime == value) return;
            startLapTime = value;
            return;
        }
    }
    
    public Text TimeText
    {
        get
        {
            return timeText;
        }
        set
        {
            if (timeText == value) return;
            timeText = value;
            return;
        }
    }
    
    void Start() {
        
    }


    private void OnEnable()
    {
        startLapTime = true;
    }

    private void OnDisable()
    { 
        LapTime = 0; 
        startLapTime = false; 
        Minute = 0;
    }

    void Update() {
        if(startLapTime){
            LapTime += Time.deltaTime;
            string t = LapTime.ToString();
            string m = Minute.ToString();
            
            if (Minute < 10){
                m = "0" + Minute.ToString() + " : ";
            }
            
            if(LapTime < 10){
                timeText.text = m + "0" + t.Substring(0, 1) + " : " + t.Substring(2, 2);
            }
            
            else {
                timeText.text = m + t.Substring(0, 2) + " : " + t.Substring(3, 2);
            }
            
            if(LapTime > 60){
                Minute += 1;
                LapTime = 0;
            }
        }
    }
}
