using UnityEngine;

public abstract class LookingTarget : MonoBehaviour
{
    protected virtual void LookAtTarget(Transform currentTrans, Transform target)
    {
        Vector3 currentPos = currentTrans.position;
        Vector3 targetPos = target.position;

        //Tính toán góc quay
        float x = targetPos.x - currentPos.x;
        float z = targetPos.z - currentPos.z;
        float angle = Mathf.Atan2(x, z) * Mathf.Rad2Deg;

        currentTrans.rotation = Quaternion.Euler(0, angle, 0);
    }
}