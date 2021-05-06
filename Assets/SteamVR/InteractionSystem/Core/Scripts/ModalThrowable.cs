//======= Copyright (c) Valve Corporation, All rights reserved. ===============
//
// Purpose: Basic throwable object
//
//=============================================================================

using UnityEngine;
using UnityEngine.Events;
using System.Collections;

namespace Valve.VR.InteractionSystem
{
    public class ModalThrowable : Throwable
    {
        [Tooltip("The local point which acts as a positional and rotational offset to use while held with a grip type grab")]
        public Transform gripOffset;

        [Tooltip("The local point which acts as a positional and rotational offset to use while held with a pinch type grab")]
        public Transform pinchOffset;

        public GameObject explodePartPrefab;
        public GameObject letterLeft;
        public GameObject letterRight;
        public int explodeCount = 10;

        private GameObject letter;

        protected override void HandHoverUpdate(Hand hand)
        {
            GrabTypes startingGrabType = hand.GetGrabStarting();

            if (startingGrabType != GrabTypes.None)
            {
                if (startingGrabType == GrabTypes.Pinch)
                {
                    // letter = gameObject.transform.GetChild(0).gameObject;
                    // Debug.Log(letter);
                    hand.AttachObject(letter, startingGrabType, attachmentFlags, pinchOffset);
                    // for (int explodeIndex = 0; explodeIndex < explodeCount; explodeIndex++)
                    // {
                    //     GameObject explodePart = (GameObject)GameObject.Instantiate(explodePartPrefab, this.transform.position, this.transform.rotation);
                    //     explodePart.GetComponentInChildren<MeshRenderer>().material.SetColor("_TintColor", Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f));
                    // }
                    // GameObject letterLeftPart = (GameObject)GameObject.Instantiate(letterLeft, this.transform.position, this.transform.rotation);
                    // GameObject letterRightPart = (GameObject)GameObject.Instantiate(letterRight, this.transform.position, this.transform.rotation);
                    // Destroy(letter);
                }
                else if (startingGrabType == GrabTypes.Grip)
                {
                    hand.AttachObject(gameObject, startingGrabType, attachmentFlags, gripOffset);
                }
                else
                {
                    hand.AttachObject(gameObject, startingGrabType, attachmentFlags, attachmentOffset);
                }

                hand.HideGrabHint();
            }
        }
        protected override void HandAttachedUpdate(Hand hand)
        {
            if (interactable.skeletonPoser != null)
            {
                interactable.skeletonPoser.SetBlendingBehaviourEnabled("PinchPose", hand.currentAttachedObjectInfo.Value.grabbedWithType == GrabTypes.Pinch);

                Debug.Log(5);
            }

            base.HandAttachedUpdate(hand);
            Debug.Log(6);
        }
    }
}