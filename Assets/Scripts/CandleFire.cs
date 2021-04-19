using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GD.MinMaxSlider;

public class CandleFire : MonoBehaviour
{
    public Light fireLight;
    public enum fireState
    { light, blink, slake };
    public fireState fire;
    [MinMaxSlider(0,5)] 
    public Vector2 lightRange;
    [MinMaxSlider(0,5)] 
    public Vector2 blinkRange;
    [MinMaxSlider(0,5)] 
    public Vector2 slakeRange;
    public float lightIntensity;

    // Start is called before the first frame update
    void Start()
    {
        fireLight = GetComponent<Light>();
    }

    // Update is called once per frame
    void Update()
    {
        fireLight.intensity = lightIntensity;
        switch (fire)
        {
            case fireState.light:
            {lightIntensity = Random.Range(lightRange.x,lightRange.y);}
                break;
            case fireState.blink:
            {lightIntensity = Random.Range(blinkRange.x,blinkRange.y);}
                break;
            case fireState.slake:
            {lightIntensity = Mathf.Lerp(slakeRange.y,slakeRange.x,Time.deltaTime);}
                break;
        }
        

    }
}
