using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;
using System;

public class EnnemyAI : MonoBehaviour
{
    private float currentCooldown;
    private bool isDead = false;
    public float attackCooldown;
    public float PlayerDetector = 10f;
    public float MinimumDistance = 6;
    public float CurrentLifeOFMonster;
    public float MaxLifeOFMonster = 100;
    public bool Chasing = false;
    public bool IsAttacking = false;
    public NavMeshAgent Monster;
    public AnimationClip Run;
    public AnimationClip Attack;
    public AnimationClip Damage;
    public AnimationClip Idle;
    public AnimationClip Die;
    public Transform Player;
    public Image HealthBar;
    public GameObject RayHit;
    

    void Start()
    {
        Monster = gameObject.GetComponent<NavMeshAgent>();
        Player = GameObject.FindGameObjectWithTag("Player").transform;
        CurrentLifeOFMonster = MaxLifeOFMonster;
    }

    void Update()
    {
        if (CurrentLifeOFMonster > 0)
        {
            var distance = Vector3.Distance(Player.transform.position, Monster.transform.position);
            if (distance <= PlayerDetector)
            {
                Chasing = true;
                FollowPlayer(distance);
                CheckDistance(distance);
            }
            else
            {
                Chasing = false;
                IsAttacking = false;
            }
            MonsterHasNoTarget();
            LookPlayer();
        }
    }

    private void FollowPlayer(float distance)
    {
        if (distance > MinimumDistance)
        {
            GetComponent<Animation>().CrossFade(Run.name);
            if (Monster.transform.position.x > 0)
            {
                Monster.destination = Player.position - new Vector3(MinimumDistance, 0, 0);
            }
            else
            {
                Monster.destination = Player.position + new Vector3(MinimumDistance, 0, 0);
            }
        }
    }

    private void CheckDistance(float distance)
    {
        if (distance <= MinimumDistance + 1)
        {
            if (!GetComponent<Animation>().IsPlaying("Damage") && !GetComponent<Animation>().IsPlaying("Attack"))
            {
                GetComponent<Animation>().CrossFade(Attack.name);
            }
            AttackPlayer();
            if (IsAttacking)
            {
                currentCooldown -= Time.deltaTime;
            }
            if (currentCooldown <= 0)
            {
                currentCooldown = attackCooldown;
                IsAttacking = false;
            }
        }
    }

    private void AttackPlayer()
    {
        if (!IsAttacking)
        {
            print("test2");
            RaycastHit hit;
            Debug.DrawLine(RayHit.transform.position, (RayHit.transform.position + transform.TransformDirection(Vector3.forward) * 1), Color.red,3);
            if (Physics.Raycast(RayHit.transform.position, transform.TransformDirection(Vector3.forward), out hit, 1))
            {
                print("test3");
               
                if (hit.transform.tag.Contains("Player"))
                {
                    hit.transform.GetComponent<Character_Motor>().IsGettingAttacked(20f);
                    print(hit.transform.name + " detected");
                }
            }
            IsAttacking = true;
            Chasing = false;
        }
    }

    public void IsGettingAttacked(float damage)
    {
        if (CurrentLifeOFMonster > 0)
        {
            GetComponent<Animation>().CrossFade(Damage.name);
            CurrentLifeOFMonster -= damage;
            print(CurrentLifeOFMonster);
            HealthBar.fillAmount = CurrentLifeOFMonster / MaxLifeOFMonster;
        }
        else
        {
            if (!isDead)
            {
                Dies();
            }
        }
    }

    private void Dies()
    {
        isDead = true;
        GetComponent<Animation>().CrossFade(Die.name);
        GiveReward();
        Destroy(Monster.gameObject, 10);
    }

    private void GiveReward()
    {
        GameObject loot = new GameObject();
        loot.name = "loops";
    //    GetComponent<RewardManager>().rewardPlayer(15, 2, loot);
    }

    private void MonsterHasNoTarget()
    {
        if (!Chasing && !Attack)
        {
            GetComponent<Animation>().CrossFade(Idle.name);
        }
    }

    private void LookPlayer()
    {
        var playerXPosition = Player.transform.position.x;
        var playerZPosition = Player.transform.position.z;
        Monster.transform.LookAt(new Vector3(playerXPosition, 0, playerZPosition));
    }
}
