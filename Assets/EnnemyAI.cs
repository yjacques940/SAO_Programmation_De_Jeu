using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnnemyAI : MonoBehaviour
{
    public Transform Player;
    public Transform CurrentEnnemy;
    public bool Chasing = true;
    int MoveSpeed = 3;
    public UnityEngine.AI.NavMeshAgent agent;
    public AnimationClip Run;
    public AnimationClip Attack;
    public float MinimumDistance = 3;
    // Use this for initialization
    void Start()
    {
        agent = gameObject.GetComponent<UnityEngine.AI.NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        var distance = Vector3.Distance(CurrentEnnemy.position, Player.position);
        if (Chasing)
        {
            GetComponent<Animation>().CrossFade(Run.name);
        }
        if(distance <= MinimumDistance)
        {
            GetComponent<Animation>().CrossFade(Attack.name);
        }
        agent.destination = Player.position;
    
    }
}

