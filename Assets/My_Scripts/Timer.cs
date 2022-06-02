using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public static Timer instance;
    public float UISelectTime = 2;
    public bool isRunning;
    public bool isDone;
    public float timeRemaining;

    [Header("UI")]
    public Renderer redRing;


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
        if (!isRunning)
        {
            Debug.Log("Start Timer");
            timeRemaining = UISelectTime;
            isRunning = true;
        }
    }

    public void Stop()
    {
        if (isRunning)
        {
            Debug.Log("Stop Timer");
            isRunning = false;
            isDone = true;
        }

    }
}
