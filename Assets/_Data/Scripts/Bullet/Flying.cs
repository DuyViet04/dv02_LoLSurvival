using UnityEngine;

public class Flying : VyesBehaviour
{
    private float flySpeed = 5f;

    //Dịch chuyển theo hướng trước mặt
    private void Update()
    {
        this.transform.parent.Translate(Vector3.forward * this.flySpeed * Time.deltaTime);
    }
}