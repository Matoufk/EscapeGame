using UnityEngine;
using UnityEngine.UI;
using System;

public class Timer_script : MonoBehaviour
{
    bool timerActive = true;
    private float currentTime;
    public int startSecondes;
    public TextMesh timeText;
    public bool timerFinit =false;

    // Start is called before the first frame update
    void Start()
    {
        //timeText.text = "00:00";
        currentTime = startSecondes;
    }

    // Update is called once per frame
    void Update()
    {
        if (timerActive == true)
        {
            currentTime = currentTime - Time.deltaTime;
            if (currentTime <= 0)
            {
                timerActive = false;
                timerFinit = true;
            }
        }
        TimeSpan time = TimeSpan.FromSeconds(currentTime);
        string time_string = time.Minutes.ToString() + ":" + time.Seconds.ToString();
        timeText.text = time_string;



    }

}