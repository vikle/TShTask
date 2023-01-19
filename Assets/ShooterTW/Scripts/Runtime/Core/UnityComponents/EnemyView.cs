using Leopotam.Ecs;
using UnityEngine;
using UnityEngine.AI;

namespace Client
{
    public class EnemyView : MonoBehaviour
    {
        public EcsEntity entity;
        public NavMeshAgent navMeshAgent;
        public float meleeAttackDistance;
        public float meleeAttackInterval;
        public float triggerDistance;
        public int startHealth;
        public int damage;
    };
}
