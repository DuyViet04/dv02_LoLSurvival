using UnityEngine;

public class PlayerLookingMouse : MonoBehaviour
{
    void Update()
    {
        if (Time.timeScale == 0) return;
    
        // Tạo một ray từ camera đến vị trí chuột
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        // Tạo một mặt phẳng nằm ngang để xác định điểm va chạm
        Plane groundPlane = new Plane(Vector3.up, Vector3.zero);

        // Kiểm tra xem ray có va chạm với mặt phẳng không
        if (groundPlane.Raycast(ray, out float enter))
        {
            Vector3 hitPoint = ray.GetPoint(enter); // Lấy điểm va chạm trên mặt phẳng
            Vector3 direction = hitPoint - transform.position; // Tính toán hướng từ vị trí người chơi đến điểm va chạm
            direction.y = 0f;
            if (direction != Vector3.zero)
            {
                Quaternion rotation = Quaternion.LookRotation(direction); // Tạo một quaternion từ hướng đã tính
                this.transform.parent.rotation = rotation;
            }
        }
    }
}