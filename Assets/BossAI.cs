using System;
using UnityEngine;
using UnityEngine.AI;


namespace Assets
{
    public class BossAI : MonoBehaviour
    {
        public bool Chasing = false;
        public bool IsAttacking = false;
        public float MinimumDistance = 6;
        public AnimationClip Run;
        public AnimationClip Attack;
        public AnimationClip Idle;
        public AnimationClip Die;
        public Transform Player;
        public Transform Boss;
        public int LifeOfBoss = 5;
        public bool IsDead = false;

        void Start()
        {
            Boss = GameObject.FindGameObjectWithTag("Boss").transform;
        }

        void Update()
        {
            if (!IsDead)
            {
                if(LifeOfBoss == 0)
                {
                    Dead();
                }
                var distance = Vector3.Distance(Player.transform.position, Boss.transform.position);
                if (DialogWithBossIsDone())
                {
                    if (IsGettingAttacked())
                    {
                        Chasing = true;
                        IsAttacking = true;
                        FollowPlayer(distance);
                        CheckDistance(distance);
                    }
                }
                else
                {
                    GetComponent<Animation>().CrossFade(Idle.name);
                }
            }
        }

        private void Dead()
        {
            IsDead = true;
            GetComponent<Animation>().CrossFade(Die.name);
            Destroy(Boss.gameObject, 10);
        }

        private bool IsGettingAttacked()
        {
            return true;
        }

        private void FollowPlayer(float distance)
        {
            GetComponent<Animation>().CrossFade(Run.name);
            if (distance > MinimumDistance)
            {
                if (Boss.transform.position.x > 0)
                {
                    Boss.position = Player.position - new Vector3(MinimumDistance, 0, 0);
                }
                else
                {
                    Boss.position = Player.position + new Vector3(MinimumDistance, 0, 0);
                }
                LookPlayer();
            }
        }

        private void LookPlayer()
        {
            var playerXPosition = Player.transform.position.x;
            var playerZPosition = Player.transform.position.z;
            Boss.transform.LookAt(new Vector3(playerXPosition, 0, playerZPosition));
        }

        private void CheckDistance(float distance)
        {
            if (distance <= MinimumDistance + 1)
            {
                IsAttacking = true;
                LookPlayer();
                GetComponent<Animation>().CrossFade(Attack.name);
                Chasing = false;
            }
        }

        private bool DialogWithBossIsDone()
        {
            return true;
        }
    }
}
