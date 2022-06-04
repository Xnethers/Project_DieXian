using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;

public class Timer : MonoBehaviour
{
    public static Timer instance;
    public float UISelectTime = 2;
    public bool isRunning;
    public bool isDone;
    public float timeRemaining;

    [Header("UI")]
    public Renderer redRing;
    public Button selectButton;


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
                float t = 360 * (timeRemaining / UISelectTime);
                redRing.material.SetFloat("_Arc1", t);
            }
            else
            {
                // timeRemaining = 0;
                isRunning = false;
                isDone = true;
                selectButton.onClick.Invoke();
            }
        }
    }

    public void StartTimer(Button select, float countdown)
    {
        if (!isRunning)
        {
            timeRemaining = UISelectTime = countdown;
            isRunning = true;
        }
    }

    public void StartTimer(Button select)
    {
        if (!isRunning)
        {
            Debug.Log("Start Timer");
            selectButton = select;
            timeRemaining = UISelectTime;
            isRunning = true;
        }
    }

    public void Stop()
    {
        if (isRunning)
        {
            Debug.Log("Stop Timer");
            selectButton = null;
            isRunning = false;
            isDone = false;
            redRing.material.SetFloat("_Arc1", 360);
        }

    }
}
