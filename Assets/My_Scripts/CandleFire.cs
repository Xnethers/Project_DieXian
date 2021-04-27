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
    [Space(10)]
    [MinMaxSlider(0, 5)]
    public Vector2 lightRange;
    public float lightTime = 0.3f;

    [Space(10)]
    [MinMaxSlider(0, 5)]
    public Vector2 blinkRange;
    public float blinkTime = 0.3f;
    [Space(10)]
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
                {
                    if (Timer())
                    { lightIntensity = Random.Range(lightRange.x, lightRange.y); }
                }
                break;
            case fireState.blink:
                {
                    if (Timer())
                    { lightIntensity = Random.Range(blinkRange.x, blinkRange.y); }
                }
                break;
            case fireState.slake:
                {
                    if (!Timer())
                    { lightIntensity = Mathf.Lerp(slakeRange.x, slakeRange.y, st); }
                }
                break;
        }
    }

    public void ToGameOver()
    {
        st = 1;
        fire = fireState.slake;
    }

    public float st = 1;
    bool Timer()
    {
        if (fire == fireState.light)
        {
            if (st > 0)
            {
                st -= Time.deltaTime / lightTime;
                return false;
            }
            else
            {
                st = 1;
                return true;
            }
        }
        else if (fire == fireState.blink)
        {
            if (st > 0)
            {
                st -= Time.deltaTime / blinkTime;
                return false;
            }
            else
            {
                st = 1;
                return true;
            }
        }
        else // (fire == fireState.slake)
        {
            if (st > 0)
            {
                st -= Time.deltaTime / slakeTime;
                return false;
            }
            else
            {
                st = 0;
                return true;
            }
        }
    }
}
