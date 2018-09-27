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
    private CharacterController controller;

    public GameObject rayHit;
    public float attackCooldown;
    private bool isAttacking;
    private float currentCooldown;
    public float attackRange = 1;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        rayHit = GameObject.Find("RayHit");
    }

    void Update()
    {
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
        //playerCamera.transform.Rotate(rotateDirection);
        //playerCamera.transform.Translate(new Vector3(0, rotateDirection[0]/25, 0));

        if (Input.GetAxis("Fire1") != 0)
        {
            Attack();
        }

        if (isAttacking)
        {
            currentCooldown -= Time.deltaTime;
        }
        if (currentCooldown <= 0)
        {
            currentCooldown = attackCooldown;
            isAttacking = false;
        }


        //Fire1 is Left Click
        //Fire3 is left Shift
    }

    public void Attack()
    {
        if (!isAttacking)
        {
            RaycastHit hit;
            if (Physics.Raycast(rayHit.transform.position, transform.TransformDirection(Vector3.forward), out hit, attackRange))
            {
                Debug.DrawLine(rayHit.transform.position, hit.point, Color.red);
                if (hit.transform.tag.Contains("Ennemy") || hit.transform.tag == "Boss")
                {
                    hit.transform.GetComponent<EnnemyAI>().IsGettingAttacked(5f);
                    print(hit.transform.name + " detected");
                }
            }
            isAttacking = true;
        }
        
    }
}