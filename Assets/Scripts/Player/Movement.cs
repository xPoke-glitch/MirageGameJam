using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public bool IsMoving { get; private set; }
    public bool IsRunning = false;

    [Header("Movement Settings")]
    [SerializeField] protected float walkSpeed = 6f;
    [SerializeField] protected float runSpeed = 10f;
    [SerializeField] private float rotationSpeed = 3f;

    protected CharacterController controller;
    PlayerAudioHandler playerAudioRef;
    PlayerAnimationHandler playerAnimationRef;
    private float minMagnitude = 0.01f;

    private void Awake()
    {
        controller = GetComponent<CharacterController>();
        playerAudioRef = GetComponent<PlayerAudioHandler>();
        playerAnimationRef = GetComponent<PlayerAnimationHandler>();

    }

    private void Update()
    {
        Move();
    }

    void Move()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        if(horizontalInput!=0 || verticalInput != 0)
        {
           /* if (!IsMoving)
            {
                playerAudioRef.PlayWalkSound();
                playerAudioRef.LoopAudio();
            }*/
            IsMoving = true;
        }
        else
        {
/*            if (IsMoving)
            {
                playerAudioRef.StopAudio();
                playerAudioRef.StopLoopingAudio();
            }*/
            IsMoving = false;
        }

        StartMoving(horizontalInput, verticalInput);
    }


    protected void StartMoving(float horizontalInput, float verticalInput)
    {
        Vector3 movementDirection = new Vector3(horizontalInput, 0, verticalInput);
        if (Input.GetKey(KeyCode.LeftShift))
        {
            controller.SimpleMove(movementDirection * runSpeed);
            IsRunning = true;
        }
        else
        {
            controller.SimpleMove(movementDirection * walkSpeed);
            IsRunning = false;
        }
        Vector3 normalizedMovementDirection = movementDirection.normalized;
        if (normalizedMovementDirection.magnitude > minMagnitude)
        {
            Quaternion currentRotation = transform.rotation;
            Quaternion wantedRotation = Quaternion.Euler(0, Vector3.SignedAngle(Vector3.forward, normalizedMovementDirection, Vector3.up), 0);
            transform.rotation = Quaternion.Lerp(currentRotation, wantedRotation, Time.deltaTime * rotationSpeed);
        }
    }

}
