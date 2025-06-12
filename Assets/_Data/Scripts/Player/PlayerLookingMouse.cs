using UnityEngine;

public class PlayerLookingMouse : MonoBehaviour
{
    void Update()
    {
        if (Time.timeScale == 0) return;

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Plane groundPlane = new Plane(Vector3.up, Vector3.zero);

        if (groundPlane.Raycast(ray, out float enter))
        {
            Vector3 hitPoint = ray.GetPoint(enter);
            Vector3 direction = hitPoint - transform.position;
            direction.y = 0f;
            if (direction != Vector3.zero)
            {
                Quaternion rotation = Quaternion.LookRotation(direction);
                this.transform.parent.rotation = rotation;
            }
        }
    }
}