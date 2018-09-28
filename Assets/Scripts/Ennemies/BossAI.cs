using System;
using UnityEngine;
using UnityEngine.AI;


namespace Assets
{
    public class BossAI : MonoBehaviour
    {
        public bool IsDead = false;
        public bool IsDialogDone = false;
        public bool Chasing = false;
        public bool IsAttacking = false;
        public float MinimumDistance = 6;
        public AnimationClip Run;
        public AnimationClip Attack;
        public AnimationClip Damage;
        public AnimationClip Idle;
        public AnimationClip Die;
        public Transform Player;
        public NavMeshAgent Boss;
        public float LifeOfBoss = 100f;
        

        void Start()
        {
            Boss = gameObject.GetComponent<NavMeshAgent>();
        }

        void Update()
        {
            if (!IsDead)
            {
                DialogWithBossIsDone();
                var distance = Vector3.Distance(Player.transform.position, Boss.transform.position);
                if (IsDialogDone)
                {
                    StartFight(distance);
                        
                }
                else
                {
                    GetComponent<Animation>().CrossFade(Idle.name);
                }
            }
        }

        private void StartFight(float distance)
        {
            Chasing = true;
            IsAttacking = true;
            FollowPlayer(distance);
            CheckDistance(distance);
        }

        public void ApplyDamageOnBoss(int damage)
        {
            LifeOfBoss = LifeOfBoss - damage;
            if (LifeOfBoss == 0)
            {
                Dead();
            }
        }

        private void Dead()
        {
            IsDead = true;
            GetComponent<Animation>().CrossFade(Die.name);
            Destroy(Boss.gameObject, 10);
        }

        private void FollowPlayer(float distance)
        {
            GetComponent<Animation>().CrossFade(Run.name);
            if (distance > MinimumDistance)
            {
                if (Boss.transform.position.x > 0)
                {
                    Boss.destination = Player.position - new Vector3(MinimumDistance, 0, 0);
                }
                else
                {
                    Boss.destination = Player.position + new Vector3(MinimumDistance, 0, 0);
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

        private void DialogWithBossIsDone()
        {
            if(Input.GetAxis("Jump") > 0)
            {
                IsDialogDone = true;
            }
        }

        public void IsGettingAttacked(float damage)
        {
            GetComponent<Animation>().CrossFade(Damage.name);
            LifeOfBoss -= damage;
            print(LifeOfBoss);
        }
    }
}
