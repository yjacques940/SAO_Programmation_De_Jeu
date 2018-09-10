using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character_Motor : MonoBehaviour {

    Animation animations;

    public float walkSpeed;
    public float runSpeed;
    public float turnSpeed;

    public string inputFront;
    public string inputBack;
    public string inputLeft;
    public string inputRight;
    public string inputCrouch;
    public string inputRun;

    public Vector3 jumpSpeed;
    CapsuleCollider playerCollider;

    void Start()
    {
        animations = gameObject.GetComponent<Animation>();
        playerCollider = gameObject.GetComponent<CapsuleCollider>();
    }

    void Update()
    {
        if (Input.GetKey(inputFront))
        {
            transform.Translate(0, 0, walkSpeed * Time.deltaTime);
            animations.Play("walk");
        }
        else if (Input.GetKey(inputBack))
        {
            transform.Translate(0, 0, -(walkSpeed / 2) * Time.deltaTime);
            animations.Play("walk");
        }

        if (Input.GetKey(inputLeft))
        {
            transform.Rotate(0, -turnSpeed * Time.deltaTime, 0);
        }
        if (Input.GetKey(inputRight))
        {
            transform.Rotate(0, turnSpeed * Time.deltaTime, 0);
        }
    }
}
