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
    [MinMaxSlider(0, 5)]
    public Vector2 lightRange;
    [MinMaxSlider(0, 5)]
    public Vector2 blinkRange;
    public float blinkTime = 0.3f;
    [MinMaxSlider(0, 5)]
    public Vector2 slakeRange;
    public float slakeTime = 0.3f;
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
                { lightIntensity = Random.Range(lightRange.x, lightRange.y); }
                break;
            case fireState.blink:
                {
                    Timer();
                    lightIntensity = Random.Range(blinkRange.x, blinkRange.y);
                }
                break;
            case fireState.slake:
                {
                    Timer();
                    lightIntensity = Mathf.Lerp(slakeRange.x, slakeRange.y, st);
                }
                break;
        }
    }

    public float st = 1;
    void Timer()
    {
        if (fire == fireState.blink)
        {
            if (st > 0)
            { st -= Time.deltaTime / blinkTime; }
            else
            { st = 1; }

        }
        else if (fire == fireState.slake)
        {
            if (st > 0)
            { st -= Time.deltaTime / slakeTime; }
            else
            { st = 1; }
        }
    }
}
