using UnityEngine;
using UnityEngine.AI;

namespace EcsGame
{
    public struct Enemy
    {
        public GameObject gameObject;
        public Transform transform;
        public NavMeshAgent navMeshAgent;
        public float meleeAttackDistance;
        public float meleeAttackInterval;
        public float triggerDistance;
        public int damage;
        public Vector3 startPosition;

        public void Die()
        {
            gameObject.SetActive(false);
        }
    };
}
