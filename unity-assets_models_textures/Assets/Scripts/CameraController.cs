using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform playerTransform;
    public float cameraSpeed = 2.0f;
    public float rotationSpeed = 2.0f;
    public Transform topPosition;

    private Vector3 offset;

    void Start()
    {
        offset = transform.position - playerTransform.position;
    }

    void LateUpdate()
    {
        // Move the camera to follow the player
        Vector3 targetPosition = playerTransform.position + offset;
        transform.position = Vector3.Lerp(transform.position, targetPosition, cameraSpeed * Time.deltaTime);

        // Restrict camera movement within the vertical range of the top position
        float clampedY = Mathf.Clamp(transform.position.y, topPosition.position.y, Mathf.Infinity);
        transform.position = new Vector3(transform.position.x, clampedY, transform.position.z);

        // Rotate the camera based on mouse movement
        if (Input.GetMouseButton(1))
        {
            float mouseX = Input.GetAxis("Mouse X") * rotationSpeed;
            float mouseY = Input.GetAxis("Mouse Y") * rotationSpeed;

            transform.RotateAround(playerTransform.position, Vector3.up, mouseX);
            transform.RotateAround(playerTransform.position, transform.right, -mouseY);
        }
    }
}
