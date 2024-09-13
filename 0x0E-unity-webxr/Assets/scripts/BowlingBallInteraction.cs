using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BowlingBallInteractions : MonoBehaviour
{

    public GameObject PlayerController;
    public GameObject BowlingBall;
    public float Speed;
    public bool BallMove = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("AlleyFloor"))
        {
            Debug.Log("Touched");
            PlayerController.GetComponentInChildren<KeyboardMovement>().enabled = false;

            BallMove = true;
        }
    }

    public void OnTriggerExit(Collider other)
    {
        PlayerController.GetComponentInChildren<KeyboardMovement>().enabled = true;
        BallMove = false;
    }

    public void Move()
    {
        if (BallMove == true)
        {
            Vector3 Movement = new Vector3(Input.GetAxis("Horizontal"), 0, 0);

            BowlingBall.transform.position += Movement * Speed * Time.deltaTime;
        }
    }
}