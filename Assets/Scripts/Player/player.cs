using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using Unity.Collections.LowLevel.Unsafe;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using System;

public class player : MonoBehaviour
{

    int experience;
    int skillpoints;
    int level;
    [SerializeField] Weapon weapon;
    private Vector3 rotateDirection = Vector3.zero;
    private Vector3 moveDirection = Vector3.zero;
    private float currentCooldown;
    private bool isAttacking;
    private float inputH;
    private float inputV;
    private float myAng = 0;
    private const float percentageToStealToEnnemy = 0.3f;
    private CharacterController controller;
    [SerializeField] Camera playerCamera;
    public float rotationSpeed = 6.0F;
    public float movingSpeed = 6.0F;
    public float jumpSpeed = 8.0F;
    public float gravity = 20.0F;
    public float baseAttackDamage = 5f;
    public Animator anim;
    public GameObject rayHit;
    public float attackCooldown;
    public float attackRange = 1;
    public Image HealthBar;
    public float MaxHealth = 200;
    public float CurrentHealth;
    private int numberOfEnnemiesKilled = 0;

    // Use this for initialization
    void Start()
    {
        controller = GetComponent<CharacterController>();
        rayHit = GameObject.Find("RayHit");
        CurrentHealth = MaxHealth;
        anim = GetComponent<Animator>();
        equipWeapon();
    }

    public void ReceiveRewards(int experienceReceived, int skillPointsReceived, GameObject itemReceived)
    {
        ReceiveExperiencePoints(experienceReceived);
        ReceiveSkillPoints(skillPointsReceived);
        AddItemToInventory(itemReceived);
    }

    void ReceiveExperiencePoints(int experienceReceived)
    {
        experience += experienceReceived;
    }

    void ReceiveSkillPoints(int skillPointsReceived)
    {
        skillpoints += skillPointsReceived;
    }

    void AddItemToInventory(GameObject itemReceived)
    {
        //complete when inventory system is defined
        print(itemReceived.name);
    }

    void equipWeapon()
    {
        GameObject weaponEquipped;
        weaponEquipped = Instantiate(Resources.Load("Weapons/" + weapon.name)) as GameObject;
        weaponEquipped.transform.position = GameObject.FindGameObjectWithTag("PlayerWeaponHand").transform.position;
        weaponEquipped.transform.rotation = GameObject.FindGameObjectWithTag("PlayerWeaponHand").transform.rotation;
        weaponEquipped.transform.parent = GameObject.FindGameObjectWithTag("PlayerWeaponHand").transform;
    }
    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        myAng = Vector3.Angle(Vector3.up, hit.normal); //Calc angle between normal and character
    }

    void Update()
    {
        if (Cursor.visible && Time.timeScale > 0)
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }

        if (Time.timeScale > 0 && CurrentHealth > 0)
        {
            if (controller.isGrounded)
            {
                inputH = Input.GetAxis("Horizontal") * 2;
                inputV = Input.GetAxis("Vertical") * 2;
                anim.SetFloat("inputH", inputH);
                anim.SetFloat("inputV", inputV);

                moveDirection = new Vector3(inputH * 20f * Time.deltaTime, 0, inputV * 50f * Time.deltaTime);
                if (Input.GetAxis("Fire3") > 0)
                {
                    moveDirection[2] *= 2F;

                }
                moveDirection = transform.TransformDirection(moveDirection);
                moveDirection *= movingSpeed;

                if (Input.GetButton("Jump") && myAng < 45)
                {
                    anim.SetBool("jump", true);
                    moveDirection.y = jumpSpeed * Time.deltaTime * 90f;
                    if (moveDirection.y == 0 && inputV > 0)
                    {
                        anim.SetFloat("inputH", inputH);
                        anim.SetFloat("inputV", inputV);
                    }
                }
                else
                {
                    anim.SetBool("jump", false);
                }

            }

            rotateDirection = new Vector3(-Input.GetAxis("Mouse Y"), Input.GetAxis("Mouse X"), 0);
            rotateDirection *= rotationSpeed;

            moveDirection.y -= gravity * Time.deltaTime;
            controller.Move(moveDirection * Time.deltaTime);
            this.transform.Rotate(new Vector3(0, rotateDirection[1], 0));

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
        }
    }

    public void Attack()
    {
        if (!isAttacking)
        {
            anim.Play("Attack");
            RaycastHit hit;
            if (Physics.Raycast(rayHit.transform.position, transform.TransformDirection(Vector3.forward), out hit, attackRange))
            {
                Debug.DrawLine(rayHit.transform.position, hit.point, Color.red);
                if (hit.transform.tag.Contains("Ennemy") || hit.transform.tag == "Boss")
                {
                    if (!hit.transform.GetComponent<EnnemyAI>().isDead)
                    {
                        float attackDamage = baseAttackDamage;
                        if (weapon)
                        {
                            attackDamage += weapon.Damage;
                        }
                        hit.transform.GetComponent<EnnemyAI>().IsGettingAttacked(attackDamage);
                        if (hit.transform.GetComponent<EnnemyAI>().isDead)
                            HealPlayer(hit);
                    }
                   
                }
            }
            isAttacking = true;
        }
    }

    private void HealPlayer(RaycastHit hit)
    {
        var lifeToHeal = hit.transform.GetComponent<EnnemyAI>().MaxLifeOFMonster * percentageToStealToEnnemy;
        if(CurrentHealth + lifeToHeal < MaxHealth)
        {
            CurrentHealth = CurrentHealth + lifeToHeal;
            
        }
        else
        {
            CurrentHealth = MaxHealth;
        }
        HealthBar.fillAmount = CurrentHealth / MaxHealth;
        IncreaseNumberOfKilledEnnemies();
    }

    private void IncreaseNumberOfKilledEnnemies()
    {
        numberOfEnnemiesKilled++;
        GetComponentInChildren<QuestManager>().UpdateText(numberOfEnnemiesKilled);
    }

    public bool IsDead()
    {
        return (CurrentHealth <= 0);
    }

    public void DeclareDead()
    {
        anim.SetBool("isDead", true);
        anim.Play("DAMAGED01");
    }

    public void IsGettingAttacked(float damage)
    {
        if (!IsDead())
        {
            if (!isAttacking)
                anim.Play("DAMAGED00");
            CurrentHealth -= damage;
            HealthBar.fillAmount = CurrentHealth / MaxHealth;
            if (IsDead()) DeclareDead();
        }
    }

}
