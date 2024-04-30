using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerController : MonoBehaviour
{

    public float threshold;
    CharacterController myCharController;
    Animator tyAnimator;

    private float speed = 10f;
    private float jmpFrc = 20f;

    private const float gravity = 25f;

    private Vector3 mvng;
    public AudioSource footSteps;


    void Start()
    {
        myCharController = GetComponent<CharacterController>();
        tyAnimator = GetComponentInChildren<Animator>();
        mvng = Vector3.zero;   
    }

    void Update()
    {
        mvmnt();
    }

    void mvmnt()
    {
        if(myCharController.isGrounded)
        {

            mvng = new Vector3(Input.GetAxis("Horizontal"),0f, Input.GetAxis("Vertical"));
            mvng *= speed;
            mvng = transform.rotation * mvng;
            
            if(Input.GetButton("Jump"))
            {
                mvng.y = jmpFrc;
                tyAnimator.SetBool("IsJump", true);
            }
            else
            {
                tyAnimator.SetBool("IsJump", false);

            }
            tyAnimator.SetBool("IsFalling", false);
        }

        if (myCharController.velocity.x != 0)
        {
            tyAnimator.SetBool("IsRunning", true);
        }
        else
        {
            tyAnimator.SetBool("IsRunning", false);
        }
        var IsRunning = tyAnimator.GetBool("IsRunning");
        mvng.y -= gravity * Time.deltaTime;

        myCharController.Move(mvng * Time.deltaTime);

        if(transform.position.y < threshold)
        {
            tyAnimator.SetBool("IsFalling", true);
            transform.position = new Vector3(0f, 25f, 0f);
            
        }
        if (myCharController.isGrounded && IsRunning == true)
            {
            //footSteps.clip = Resources.Load<AudioClip>("footsteps-running-rock");
               footSteps.Play();
            }

    }
}