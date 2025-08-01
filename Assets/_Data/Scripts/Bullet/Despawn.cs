using UnityEngine;

public class Despawn : VyesBehaviour
{
    //Despawn khi ra khỏi màn hình
    private void Update()
    {
        bool isOnScreen = this.IsOnScreen();
        if (isOnScreen) return;
        BulletSpawner.Instance.Despawn(this.transform.parent);
    }

    bool IsOnScreen()
    {
        Vector3 screenPoint = Camera.main.WorldToViewportPoint(this.transform.parent.position);
        bool isOnScreen = screenPoint.x >= 0 && screenPoint.x <= 1 &&
                          screenPoint.y >= 0 && screenPoint.y <= 1 &&
                          screenPoint.z > 0;
        return isOnScreen;
    }
}