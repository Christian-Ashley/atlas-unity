using UnityEngine;

public class CharacterController : MonoBehaviour
{
    public float moveSpeed = 10f;
    public float jumpForce = 5f;
    public float gravity = -9.81f;
    public float teleportRadius = 5f;

    private CharacterController characterController;
    private Transform headBone;
    private Vector3 velocity;
    private InputActionAsset playerControls;

    private void Awake()
    {
        characterController = GetComponent<CharacterController>();
        headBone = transform.Find("Head").gameObject != null ? transform.Find("Head") : transform;
        playerControls = Resources.Load<InputActionAsset>("PlayerControls");
        if (playerControls == null)
        {
            Debug.LogError("Failed to load Input Action Asset!");
            return;
        }
    }

    private void Start()
    {
        playerControls.Enable();
    }

    private void Update()
    {
        HandleMovement();
        ApplyGravity();

        // Switch VR mode if necessary
        if (!IsVrModeActive() && WebXRInputUtility.IsWebXRActive())
        {
            SwitchToVrMode();
        }
        else if (IsVrModeActive() && !WebXRInputUtility.IsWebXRActive())
        {
            SwitchToNonVrMode();
        }
    }

    private void HandleMovement()
    {
        Vector3 movement = CalculateMovement();

        if (characterController.isGrounded)
        {
            characterController.Move(movement * Time.deltaTime);
        }
        else
        {
            velocity += movement * Time.fixedDeltaTime;
            characterController.Move(velocity);
        }
    }

    private Vector3 CalculateMovement()
    {
        Vector3 movement = Vector3.zero;

        if (IsVrModeActive())
        {
            movement += GetVrMovement();
        }
        else
        {
            movement += GetNonVrMovement();
        }

        return movement;
    }

    private Vector3 GetVrMovement()
    {
        return playerControls.Controls.Move.ReadValue<Vector3>();
    }

    private Vector3 GetNonVrMovement()
    {
        float horizontal = playerControls.Controls.HorizontalJoystick.ReadValue<float>();
        float vertical = playerControls.Controls.VerticalJoystick.ReadValue<float>();

        return new Vector3(horizontal, 0, vertical);
    }

    private void ApplyGravity()
    {
        characterController.AddForce(Vector3.down * gravity, ForceMode.Acceleration);
    }

    private bool IsVrModeActive()
    {
        return WebXRInputUtility.IsWebXRActive();
    }

    public void Teleport(Vector3 direction)
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, direction, out hit, teleportRadius))
        {
            transform.position = hit.point;
        }
        else
        {
            transform.position += direction * moveSpeed * Time.deltaTime;
        }
    }

    private void SwitchToVrMode()
    {
        // Implement VR-specific logic here
    }

    private void SwitchToNonVrMode()
    {
        // Implement non-VR-specific logic here
    }

    private void OnDisable()
    {
        playerControls.Disable();
    }
}
