using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class nowPos : MonoBehaviour
{
    public Text noweyePos;
    public GameObject eyeRing;


    public GameObject ray_L;
    private LineRenderer lineRenderer_L;
    void Start()
    {
        lineRenderer_L = ray_L.GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        noweyePos.text = eyeRing.transform.position.ToString();

        lineRenderer_L.SetPosition(0,ray_L.transform.position);
        lineRenderer_L.SetPosition(1,eyeRing.transform.position);
    }
}
