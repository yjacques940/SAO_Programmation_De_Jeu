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
    public AnimationClip Damage;
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
        }
        else
        {
            Chasing = false;
            IsAttacking = false;
        }
        MonsterHasNoTarget();
        LookPlayer();
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
            IsAttacking = true;
            Chasing = false;
        }
    }

    public void IsGettingAttacked(float damage)
    {
        GetComponent<Animation>().CrossFade(Damage.name);
        LifeOFMonster -= damage;
        print(LifeOFMonster);
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
