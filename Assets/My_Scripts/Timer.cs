using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public static Timer instance;
    public float UISelectTime = 2;
    public bool isRunning;
    public bool isDone;
    public float timeRemaining;
    

    private void Awake() 
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (isRunning)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
            }
            else
            {
                Debug.Log(timeRemaining);
                // timeRemaining = 0;
                isRunning = false;
                isDone = true;
            }
        }
    }

    public void StartTimer(float countdown)
    {
        timeRemaining = countdown;
        isRunning = true;
    }

    public void StartTimer()
    {
        Debug.Log("StartTimer");
        timeRemaining = UISelectTime;
        isRunning = true;
    }

    public void Stop()
    {
        isRunning = false;
        isDone = true;        
    }
}
