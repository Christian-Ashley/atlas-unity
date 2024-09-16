using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BowlingBallInteractions : MonoBehaviour
{
    public GameObject PlayerController;
    public GameObject BowlingBall;
    public float Speed = 10f;
    public bool BallMove = false;

    private CharacterController characterController;

    private void Awake()
    {
        characterController = PlayerController.GetComponent<CharacterController>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("AlleyFloor"))
        {
            Debug.Log("bonk");
            PlayerController.GetComponentInChildren<KeyboardMovement>().enabled = false;

            BallMove = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        PlayerController.GetComponentInChildren<KeyboardMovement>().enabled = true;
        BallMove = false;
    }

    private void Update()
    {
        if (BallMove)
        {
            Move();
        }
    }

    private void Move()
    {
        Vector3 Movement = new Vector3(Input.GetAxis("Horizontal"), 0, 0);

        characterController.Move(Movement * Speed * Time.deltaTime);
    }
}
