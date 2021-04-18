using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class Bowl : MonoBehaviour
{
    public SteamVR_Action_Boolean m_GrabAction = null;
    public bool isHold;
    private SteamVR_Behaviour_Pose m_Pose = null;
    private FixedJoint m_Joint = null;

    private void Awake()
    {
        m_Pose = GetComponent<SteamVR_Behaviour_Pose>();
        m_Joint = GetComponent<FixedJoint>();
    }
    private void Update()
    {

    }

    private void OnTriggerStay(Collider other)
    {
        if (other.transform.root.name == "Player")
        {
            if (m_GrabAction.GetStateDown(m_Pose.inputSource))
            { isHold = true; }
            else
            { isHold = false; }
        }
        if (!isHold)
        { Debug.Log("Game Over"); }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.transform.root.name == "Player")
        {
            if (isHold)
            { Debug.Log("Game Over"); }
        }
    }
}
