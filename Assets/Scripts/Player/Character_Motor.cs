using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character_Motor : MonoBehaviour {
    
    public float movingSpeed = 6.0F;
    public float rotationSpeed = 6.0F;
    public float jumpSpeed = 8.0F;
    public float gravity = 20.0F;
    private Vector3 moveDirection = Vector3.zero;
    private Vector3 rotateDirection = Vector3.zero;

    void Start() {}

    void Update()
    {
        CharacterController controller = GetComponent<CharacterController>();
        if (controller.isGrounded)
        {
            moveDirection = new Vector3(0, 0, Input.GetAxis("Vertical"));
            if (Input.GetAxis("Fire3") > 0) moveDirection[2] *= 2F;
            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection *= movingSpeed;

            rotateDirection = new Vector3(0, Input.GetAxis("Horizontal"), 0);
            rotateDirection *= movingSpeed;

            if (Input.GetButton("Jump"))
                moveDirection.y = jumpSpeed;

        }
        moveDirection.y -= gravity * Time.deltaTime;
        controller.Move(moveDirection * Time.deltaTime);
        transform.Rotate(rotateDirection);

        //Fire1 is Left CTRL
        //Fire3 is left Shift
    }
}