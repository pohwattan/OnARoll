using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class TimerCanvas : MonoBehaviour
{
    [SerializeField] private float remainingTime = 120; // seconds
    private Text time;
    private float timeToDisplay;
    private bool timerActive = false;

    public bool isActive => timerActive;


    private void OnEnable()
    {
        EventManager.TimerAdderCollected += AddTime;
    }

    private void OnDisable()
    {
        EventManager.TimerAdderCollected -= AddTime;
    }

    void Start()
    {
        time = GetComponent<Text>();
        if (time == null)
            throw new System.Exception("Null Reference within TimerCanvas.cs.");
        if (remainingTime > 0)
            timerActive = true;
    }
    
    void Update()
    {
        if (timerActive && remainingTime > 0)
        {
            UpdateTimer();
        }
        else if (timerActive && remainingTime <= 0)
        {
            timerActive = false;
            EventManager.TriggerTimerExpired();
        }
    }

    private void UpdateTimer()
    {
        remainingTime -= Time.deltaTime;

        float minutes = Mathf.FloorToInt(remainingTime / 60); 
        float seconds = Mathf.FloorToInt(remainingTime % 60);

        if (minutes > 0) {
            time.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        } else {
            seconds = Mathf.FloorToInt((remainingTime % 60) * 100);
            time.text = string.Format("{0:00}:{1:0000}", minutes, seconds);
        }
    }

    private void AddTime()
    {
        remainingTime += 20;
    }
}
