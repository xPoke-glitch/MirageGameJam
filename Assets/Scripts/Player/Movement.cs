using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [Header("Movement Settings")]
    [SerializeField] protected float walkSpeed = 6f;
    [SerializeField] private float rotationSpeed = 3f;


    protected CharacterController controller;
    private float minMagnitude = 0.01f;


    private void Awake()
    {
        controller = GetComponent<CharacterController>();
    }

    private void Update()
    {
        Move();
    }

    void Move()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        StartMoving(horizontalInput, verticalInput);
    }


    protected void StartMoving(float horizontalInput, float verticalInput)
    {
        Vector3 movementDirection = new Vector3(horizontalInput, 0, verticalInput);
        controller.SimpleMove(movementDirection * walkSpeed);
        Vector3 normalizedMovementDirection = movementDirection.normalized;
        if (normalizedMovementDirection.magnitude > minMagnitude)
        {
            Quaternion currentRotation = transform.rotation;
            Quaternion wantedRotation = Quaternion.Euler(0, Vector3.SignedAngle(Vector3.forward, normalizedMovementDirection, Vector3.up), 0);
            transform.rotation = Quaternion.Lerp(currentRotation, wantedRotation, Time.deltaTime * rotationSpeed);
        }
    }

}
