using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtTarget : MonoBehaviour
{
    public Transform target;
    public bool LockX = false;
    public bool LockY = false;
    public bool LockZ = false;

    private Quaternion originRotation;


    // Start is called before the first frame update
    void Start()
    {
        if (target == null)
        {
            target = GameObject.Find("VRCamera (eye)").transform;
        }
        originRotation = transform.rotation;

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 targetPos = new Vector3(target.position.x, target.position.y, target.position.z);
        if (LockX)
        { targetPos.x = transform.position.x; }
        if (LockY)
        { targetPos.y = transform.position.y; }
        if (LockZ)
        { targetPos.z = transform.position.z; }
        transform.LookAt(targetPos);
    }

    /// <summary>
    /// 用某個軸去朝向物體
    /// </summary>
    /// <param name="transform">朝向的本體</param>
    /// <param name="lookPos">朝向的目標</param>
    /// <param name="directionAxis">方向軸，取決於你用那個方向去朝向</param>
    void AxisLookAt(Vector3 lookPos, Vector3 directionAxis)
    {
        var rotation = transform.rotation;
        var targetDir = lookPos - transform.position;
        //指定哪根軸朝向目標,自行修改Vector3的方向
        var fromDir = transform.rotation * directionAxis;
        //計算垂直於當前方向和目標方向的軸
        var axis = Vector3.Cross(fromDir, targetDir).normalized;
        //計算當前方向和目標方向的夾角
        var angle = Vector3.Angle(fromDir, targetDir);
        //將當前朝向向目標方向旋轉一定角度，這個角度值可以做插值
        transform.rotation = Quaternion.AngleAxis(angle, axis) * rotation;
        transform.localEulerAngles = new Vector3(0, transform.localEulerAngles.y, 90);//後來調試增加的，因為我想讓x，z軸向不會有任何變化
    }
}
