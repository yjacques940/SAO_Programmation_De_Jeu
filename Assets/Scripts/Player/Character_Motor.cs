using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character_Motor : MonoBehaviour {

    private Vector3 rotateDirection = Vector3.zero;
    private Vector3 moveDirection = Vector3.zero;
    [SerializeField] Camera playerCamera;
    [SerializeField] GameObject player;
    public float rotationSpeed = 6.0F;
    public float movingSpeed = 6.0F;
    public float jumpSpeed = 8.0F;
    public float gravity = 20.0F;

    void Start() {}

    void Update()
    {
        CharacterController controller = GetComponent<CharacterController>();
        if (controller.isGrounded)
        {
            moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            if (Input.GetAxis("Fire3") > 0) moveDirection[2] *= 2F;
            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection *= movingSpeed;

            rotateDirection = new Vector3(-Input.GetAxis("Mouse Y"), Input.GetAxis("Mouse X"), 0);
            rotateDirection *= rotationSpeed;

            if (Input.GetButton("Jump")) moveDirection.y = jumpSpeed;

        }
        moveDirection.y -= gravity * Time.deltaTime;
        controller.Move(moveDirection * Time.deltaTime);
        player.transform.Rotate(new Vector3(0, rotateDirection[1], 0));
        playerCamera.transform.Rotate(rotateDirection);
        //playerCamera.transform.Translate(new Vector3(0, rotateDirection[0]/25, 0));


        //Fire1 is Left CTRL
        //Fire3 is left Shift
    }
}