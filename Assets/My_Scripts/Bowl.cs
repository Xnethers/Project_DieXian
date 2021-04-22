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
    private DialogueSystemTrigger dst;
    private Hand _hand;
    private void Awake()
    {
        interactable = this.GetComponent<Interactable>();
        poser = GetComponent<SteamVR_Skeleton_Poser>();
        dst = GetComponent<DialogueSystemTrigger>();
    }
    private void Update()
    {
        if (interactable.isHovering != lastHovering) //save on the .tostrings a bit
        { lastHovering = interactable.isHovering; }

        if (QuestLog.GetQuestState("不要移開") == QuestState.Active)
        {
            if (isHold)
            { }
            else
            {
                QuestLog.SetQuestState("不要移開", QuestState.Failure);
            }
        }
    }
    private void HandHoverUpdate(Hand hand)
    {
        dst.OnUse();
        _hand = hand;
        GrabTypes startingGrabType = hand.GetGrabStarting();
        bool isGrabEnding = hand.IsGrabEnding(this.gameObject);

        if (interactable.attachedToHand == null && startingGrabType != GrabTypes.None)
        {
            isHold = true;
            DialogueLua.SetVariable("IsHold", true);
        }
        else if (isGrabEnding)
        {
            isHold = false;
        }
    }

    private void OnHandHoverBegin(Hand hand)
    {
        hand.skeleton.BlendToPoser(poser, 0.1f);
    }

    private void OnHandHoverEnd(Hand hand)
    {
        hand.skeleton.BlendToSkeleton(0.1f);
        if (isHold)
        {
            isHold = false;
            DialogueLua.SetVariable("IsHold", true);
        }
    }

    // IEnumerator TIMER()
    // {
    //     yield return new WaitForSeconds(0.2f);
    //     isHold = false;
    // }

    void GameOver()
    {

    }
}
