using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public float rotationSpeed;
    public float jumpSpeed;
    public Transform startPosition;

    private CharacterController characterController;
    private float ySpeed;

    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();
        ResetPlayer();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 moveDirection = new Vector3(horizontalInput, 0, verticalInput);
        float magnitude = Mathf.Clamp01(moveDirection.magnitude) * speed;
        moveDirection.Normalize();

        ySpeed += Physics.gravity.y * Time.deltaTime;

        if (characterController.isGrounded)
        {
            ySpeed = -0.5f;

            if (Input.GetButtonDown("Jump"))
            {
                ySpeed = jumpSpeed;
            }
        }

        Vector3 velocity = moveDirection * magnitude;
        velocity.y = ySpeed;

        characterController.Move(velocity * Time.deltaTime);

        if (moveDirection != Vector3.zero)
        {
            Quaternion toRotation = Quaternion.LookRotation(moveDirection, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
        }

        if (transform.position.y < -10f)
        {
            ResetPlayer();
        }
    }

    private void ResetPlayer()
    {
        characterController.enabled = false;
        transform.position = startPosition.position;
        characterController.enabled = true;
    }
}