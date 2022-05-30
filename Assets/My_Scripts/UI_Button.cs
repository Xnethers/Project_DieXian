using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

using Tobii.G2OM;
using Tobii.XR.Examples.GettingStarted;

public class UI_Button : MonoBehaviour, IGazeFocusable
{
    public Text txt;
    public Color highlightColor;
    private Color originalColor;
    // Start is called before the first frame update
    void Start()
    {
        txt = GetComponentInChildren<Text>();
        originalColor = txt.color;
    }

    // Update is called once per frame
    void Update()
    {
        // uiSettings.GetObjectsHitByRay(uiSettings.);
    }

    public void GazeFocusChanged(bool hasFocus)
    {
        //If this object received focus, fade the object's color to highlight color
        if (hasFocus)
        {
            txt.color = highlightColor;
            Timer.instance.StartTimer();
        }
        //If this object lost focus, fade the object's color to it's original color
        else
        {
            txt.color = Color.white;
            Timer.instance.Stop();
        }
    }
}
