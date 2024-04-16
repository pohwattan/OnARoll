using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerCanvas : MonoBehaviour
{
    public static float timeValue = 63; // time in seconds
    private Text time;
    private float timeToDisplay;

    // Start is called before the first frame update
    void Start()
    {
        time = GetComponent<Text>();
        if (time == null)
            Debug.Log("Null Reference within TimerCanvas.cs.");
    }

    // Update is called once per frame
    void Update()
    {
        timeValue -= Time.deltaTime;
        timeToDisplay = timeValue + 1;

        float minutes = Mathf.FloorToInt(timeToDisplay / 60); 
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        if (minutes > 0) {
            time.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        } else {
            seconds = Mathf.FloorToInt((timeToDisplay % 60) * 100);
            time.text = string.Format("{0:00}:{1:0000}", minutes, seconds);
        }
    }
}
