using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;
using System;

public class EnnemyAI : MonoBehaviour
{
    public float PlayerDetector = 10f;
    public float MinimumDistance = 6;
    public float LifeOFMonster = 100f;
    public bool Chasing = false;
    public bool IsAttacking = false;
    public NavMeshAgent Monster;
    public AnimationClip Run;
    public AnimationClip Attack;
    public AnimationClip Idle;
    public AnimationClip Die;
    public Transform Player;
    

    void Start()
    {
        Monster = gameObject.GetComponent<NavMeshAgent>();
        Player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        var distance = Vector3.Distance(Player.transform.position, Monster.transform.position);
        if(distance <= PlayerDetector)
        {
            Chasing = true;
            FollowPlayer(distance);
            CheckDistance(distance);
            MonsterHasNoTarget();
        }
        else
        {
            Chasing = false;
            IsAttacking = false;
            MonsterHasNoTarget();
        }
    }

    private void FollowPlayer(float distance)
    {
        GetComponent<Animation>().CrossFade(Run.name);
        if (distance > MinimumDistance)
        {
            if (Monster.transform.position.x > 0)
            {
                Monster.destination = Player.position - new Vector3(MinimumDistance, 0, 0);
            }
            else
            {
                Monster.destination = Player.position + new Vector3(MinimumDistance, 0, 0);
            }
            LookPlayer();
        }
    }

    private void CheckDistance(float distance)
    {
        if (distance <= MinimumDistance + 1)
        {
            IsAttacking = true;
            LookPlayer();
            GetComponent<Animation>().CrossFade(Attack.name);
            Chasing = false;
            //IsGettingAttacked(distance);
        }
    }

    public void IsGettingAttacked(float damage)
    {
        //if (distance < MinimumDistance + 3) {
            LifeOFMonster -= damage;
            print(LifeOFMonster);
        //}
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

