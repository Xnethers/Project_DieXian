using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void FadeIn(float duration = 0.5f)
    { SteamVR_Fade.View(Color.black, duration); }

    public void FadeOut(float duration = 0.5f)
    { SteamVR_Fade.View(Color.clear, duration); }


    IEnumerator Scene1_GameOver()
    {
        return null;
    }
}