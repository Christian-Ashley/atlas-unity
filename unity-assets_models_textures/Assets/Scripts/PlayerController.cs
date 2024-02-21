using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControler : MonoBehaviour
{
     public float speed = 5f;
     public int jumpHeight = 10;
     public int Gravity = 5;

    // Start is called before the first frame update
    void Start()
    {
     ///start unnecassary   
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0f, moveVertical);
        movement.Normalize(); // Normalize the movement vector to prevent faster diagonal movement

        movement.y = -Gravity * Time.deltaTime;

        transform.Translate(movement * speed * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
    }
    void Jump()
    {
        Vector3 newPosition = transform.position;
        newPosition.y += jumpHeight;
        transform.position = newPosition;
    }
}