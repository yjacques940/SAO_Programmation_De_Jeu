using System.Collections;
using System.Collections.Generic;
using Devdog.InventoryPro;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class Character_Motor : MonoBehaviour {

    private Vector3 rotateDirection = Vector3.zero;
    private Vector3 moveDirection = Vector3.zero;
    private CharacterController controller;
    [SerializeField] Camera playerCamera;
    [SerializeField] GameObject player;
    public float rotationSpeed = 6.0F;
    public float movingSpeed = 6.0F;
    public float jumpSpeed = 8.0F;
    public float gravity = 20.0F;

    private float currentCooldown;
    private bool isAttacking;
    public GameObject rayHit;
    public float attackCooldown;
    public float attackRange = 1;
    public Image HealthBar;
    public float MaxHealth = 200;
    public float CurrentHealth;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        rayHit = GameObject.Find("RayHit");
        CurrentHealth = MaxHealth;
    }

    void Update()
    {
        if (controller.isGrounded)
        {
            moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            if (Input.GetAxis("Fire3") > 0)
            {
                moveDirection[2] *= 2F;
            }
            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection *= movingSpeed;

            if (Input.GetButton("Jump"))
            {
                moveDirection.y = jumpSpeed;
            }

        }

        rotateDirection = new Vector3(-Input.GetAxis("Mouse Y"), Input.GetAxis("Mouse X"), 0);
        rotateDirection *= rotationSpeed;

        moveDirection.y -= gravity * Time.deltaTime;
        controller.Move(moveDirection * Time.deltaTime);
        player.transform.Rotate(new Vector3(0, rotateDirection[1], 0));
        //playerCamera.transform.Rotate(rotateDirection);
        //playerCamera.transform.Translate(new Vector3(0, rotateDirection[0]/25, 0));

        if (Input.GetAxis("Fire1") != 0)
        {
            Attack();
        }

        //if (Input.GetKey("E") == true)
        //{
            //var equipSlot = equippableItem.GetBestEquipSlot(characterCollection);
            //if (equipSlot == null)
            //    return; // can't equip, no slots found.

            //characterCollection.EquipItem(equipSlot, equippableItem); // Equip the item to the character collection. 

            //// OR 
            //var bestEquipSlot = equippableItem.GetBestEquipSlot(characterCollection);
            //if (bestEquipSlot == null)
            //    return;

            //equippableItem.Equip(bestEquipSlot);
        //}

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

    public void IsGettingAttacked(float damage)
    {
        if (CurrentHealth > 0)
        {
            CurrentHealth -= damage;
            print("PLAYEER HEALTH FOR BAR" + CurrentHealth / MaxHealth);
            HealthBar.fillAmount = CurrentHealth / MaxHealth;
        }
        else
        {
            //Dies();
        }
    }
}