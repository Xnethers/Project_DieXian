using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC_TrackBowlAnimate : MonoBehaviour
{
    // 右手
    public Transform rightHandObj = null; //与相关球体对应
    // 头的观察点
    public Transform lookAtObj = null; //与相关球体对应
    // 动画机
    private Animator avatar;
    // 是否激活 IK
    public bool ikActive = false;


    void Start()
    {
        avatar = GetComponent<Animator>();
    }


    void Update()
    {
        // 如果 IK 没有激活
        // 把对应的控制部分附上动画自身的值
        if (!ikActive)
        {
            if (rightHandObj != null)
            {
                rightHandObj.position = avatar.GetIKPosition(AvatarIKGoal.RightHand);
                rightHandObj.rotation = avatar.GetIKRotation(AvatarIKGoal.RightHand);
            }

            if (lookAtObj != null)
            {
                lookAtObj.position = avatar.bodyPosition + avatar.bodyRotation * new Vector3(0, 0.5f, 1);
            }
        }
    }


    /// <summary>
    /// IK 动画的控制专用函数
    /// </summary>
    /// <param name="layerIndex">动画层</param>
    void OnAnimatorIK(int layerIndex)
    {
        // 动画机为空，返回
        if (avatar == null)
        { return; }
        // 激活 IK 
        //1、 各部分权重赋值 1
        //2、 各部分位置赋值
        //3、 部分旋转赋值
        if (ikActive)
        {
            avatar.SetIKPositionWeight(AvatarIKGoal.LeftFoot, 1.0f);
            avatar.SetIKRotationWeight(AvatarIKGoal.LeftFoot, 1.0f);
            
            avatar.SetIKPositionWeight(AvatarIKGoal.LeftFoot, 1.0f);
            avatar.SetIKRotationWeight(AvatarIKGoal.LeftFoot, 1.0f);
            avatar.SetIKPositionWeight(AvatarIKGoal.RightFoot, 1.0f);
            avatar.SetIKRotationWeight(AvatarIKGoal.RightFoot, 1.0f);
            avatar.SetIKPositionWeight(AvatarIKGoal.LeftHand, 1.0f);
            avatar.SetIKRotationWeight(AvatarIKGoal.LeftHand, 1.0f);
            avatar.SetIKPositionWeight(AvatarIKGoal.RightHand, 1.0f);
            avatar.SetIKRotationWeight(AvatarIKGoal.RightHand, 1.0f);
            avatar.SetLookAtWeight(1.0f, 0.3f, 0.6f, 1.0f, 0.5f);
            avatar.SetIKHintPositionWeight(AvatarIKHint.RightElbow, 1.0f);
            avatar.SetIKHintPositionWeight(AvatarIKHint.LeftElbow, 1.0f);
            avatar.SetIKHintPositionWeight(AvatarIKHint.RightKnee, 1.0f);
            avatar.SetIKHintPositionWeight(AvatarIKHint.LeftKnee, 1.0f);

            if (rightHandObj != null)
            {
                avatar.SetIKPosition(AvatarIKGoal.RightHand, rightHandObj.position);
                avatar.SetIKRotation(AvatarIKGoal.RightHand, (rightHandObj.rotation) * Quaternion.Euler(1, 1, 180));
            }

            if (lookAtObj != null)
            {
                avatar.SetLookAtPosition(lookAtObj.position);
            }
        }

        // 不激活 IK 
        //1、 各部分权重赋值 0    
        else
        {
            avatar.SetIKPositionWeight(AvatarIKGoal.LeftFoot, 0);
            avatar.SetIKRotationWeight(AvatarIKGoal.LeftFoot, 0);
            avatar.SetIKPositionWeight(AvatarIKGoal.RightFoot, 0);
            avatar.SetIKRotationWeight(AvatarIKGoal.RightFoot, 0);
            avatar.SetIKPositionWeight(AvatarIKGoal.LeftHand, 0);
            avatar.SetIKRotationWeight(AvatarIKGoal.LeftHand, 0);
            avatar.SetIKPositionWeight(AvatarIKGoal.RightHand, 0);
            avatar.SetIKRotationWeight(AvatarIKGoal.RightHand, 0);
            avatar.SetLookAtWeight(0.0f);
            avatar.SetIKHintPositionWeight(AvatarIKHint.RightElbow, 0);
            avatar.SetIKHintPositionWeight(AvatarIKHint.LeftElbow, 0);
            avatar.SetIKHintPositionWeight(AvatarIKHint.RightKnee, 0);
            avatar.SetIKHintPositionWeight(AvatarIKHint.LeftKnee, 0);
        }

    }

}
