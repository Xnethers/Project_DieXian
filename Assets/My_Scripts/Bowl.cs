using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;
using Valve.VR;
using PixelCrushers.DialogueSystem;

public class Bowl : MonoBehaviour
{
    public bool isHold;

    private bool lastHovering = false;
    // private FixedJoint m_Joint = null;
    private Interactable interactable;
    public Hand.AttachmentFlags attachmentFlags = Hand.defaultAttachmentFlags & (~Hand.AttachmentFlags.SnapOnAttach) & (~Hand.AttachmentFlags.DetachOthers) & (~Hand.AttachmentFlags.TurnOnKinematic);
    private SteamVR_Skeleton_Poser poser;
    private Hand _hand;
    private void Awake()
    {
        interactable = this.GetComponent<Interactable>();
        poser = GetComponent<SteamVR_Skeleton_Poser>();
    }
    private void Update()
    {

        if (interactable.isHovering != lastHovering) //save on the .tostrings a bit
        { lastHovering = interactable.isHovering; }
    }
    private void HandHoverUpdate(Hand hand)
    {
        _hand = hand;
        GrabTypes startingGrabType = hand.GetGrabStarting();
        bool isGrabEnding = hand.IsGrabEnding(this.gameObject);

        if (interactable.attachedToHand == null && startingGrabType != GrabTypes.None)
        {

        }
        else if (isHold && isGrabEnding)
        {

        }
    }

    private void OnHandHoverBegin(Hand hand)
    {
        hand.skeleton.BlendToPoser(poser, 0.1f);
        DialogueLua.SetVariable("IsHold", true);
        Debug.Log(DialogueLua.GetVariable("IsHold").AsBool);
        isHold = true;
    }

    private void OnHandHoverEnd(Hand hand)
    {
        hand.skeleton.BlendToSkeleton(0.1f);
        DialogueLua.SetVariable("IsHold", true);
        Debug.Log(DialogueLua.GetVariable("IsHold").AsBool);
        isHold = false;
    }
}
