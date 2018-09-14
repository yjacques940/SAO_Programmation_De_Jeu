using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnnemyAI : MonoBehaviour
{
    public Transform Player;
    public bool Chasing = true;
    int MoveSpeed = 3;
    public UnityEngine.AI.NavMeshAgent agent;
    public AnimationClip Run;
    public AnimationClip Attack;
    public AnimationClip Idle;
    public float MinimumDistance = 6;
    // Use this for initialization
    void Start()
    {
        agent = gameObject.GetComponent<UnityEngine.AI.NavMeshAgent>();
        Player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        var distance = Vector3.Distance(agent.transform.position, Player.transform.position);
      
        if (Chasing)
        {
            GetComponent<Animation>().CrossFade(Run.name);
        }
        if (distance > MinimumDistance)
        {
            if(agent.transform.position.x > 0)
            {
                agent.destination = Player.position - new Vector3(MinimumDistance/4, 0,0);
            }
            else
            {
                agent.destination = Player.position + new Vector3(MinimumDistance/4, 0,0);
            }
        }
        if (distance <= MinimumDistance+1)
        {
            GetComponent<Animation>().CrossFade(Attack.name);
            Chasing = false;
        }
        //if(!Chasing && !Attack)
        //{
        //    GetComponent<Animation>().CrossFade(Idle.name);
        //}
       
    }
}

