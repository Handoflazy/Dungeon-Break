using UnityEngine;

public class PointCamera : MonoBehaviour
{
    public Camera mainCamera; // Kéo và thả Camera mà Canvas sẽ theo dõi
    public float offset = 10f; // Độ lệch so với góc trên bên trái

    void Update()
    {
        // Lấy vị trí của góc trên bên trái của camera
        Vector3 cameraCorner = mainCamera.ScreenToWorldPoint(new Vector3(0, Screen.height, mainCamera.nearClipPlane + offset));

        // Đặt vị trí của Canvas để nó nằm ở góc trên bên trái của camera
        transform.position = new Vector3(cameraCorner.x, cameraCorner.y, transform.position.z);
    }
}
