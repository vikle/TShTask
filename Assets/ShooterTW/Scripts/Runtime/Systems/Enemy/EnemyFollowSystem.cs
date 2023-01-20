using Leopotam.Ecs;
using UnityEngine;

namespace Client
{
    sealed class EnemyFollowSystem : IEcsRunSystem
    {
        readonly EcsWorld m_world;
        EcsFilter<Enemy, Follow> m_filter;

        void IEcsRunSystem.Run()
        {
            foreach (int i in m_filter)
            {
                ref var enemy = ref m_filter.Get1(i);
                ref var follow = ref m_filter.Get2(i);
                
                if (follow.target.IsAlive() == false)
                {
                    ref var entity = ref m_filter.GetEntity(i);
                    entity.Del<Follow>();
                    enemy.navMeshAgent.SetDestination(enemy.startPosition);
                    continue;
                }
                
                ref var transform_ref = ref follow.target.Get<TransformRef>();
                var target_pos = transform_ref.transform.position;
                enemy.navMeshAgent.SetDestination(target_pos);
                var e_tr = enemy.transform;
                var direction = (target_pos - e_tr.position).normalized;
                direction.y = 0f;
                e_tr.forward = direction;

                float sqr_dist = (enemy.transform.position - transform_ref.transform.position).sqrMagnitude;
                float sqr_attack_dist = enemy.meleeAttackDistance * enemy.meleeAttackDistance;
                if (sqr_dist < sqr_attack_dist && Time.time >= follow.nextAttackTime)
                {
                    follow.nextAttackTime = Time.time + enemy.meleeAttackInterval;
                    ref var e = ref m_world.NewEntity().Get<DamageEvent>();
                    e.target = follow.target;
                    e.value = enemy.damage;
                }
            }
        }
    };
}
