using Leopotam.Ecs;
using UnityEngine;
using UnityEngine.AI;

namespace EcsGame
{
    public class EnemyView : MonoBehaviour
    {
        public EcsEntity entity;
        public NavMeshAgent navMeshAgent;
        public float meleeAttackDistance;
        public float meleeAttackInterval;
        public float triggerDistance;
        public int startHealth;
        public float startShield;
        public int damage;
    };
}
