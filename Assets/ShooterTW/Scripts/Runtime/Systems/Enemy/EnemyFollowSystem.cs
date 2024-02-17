using Leopotam.Ecs;
using UnityEngine;

namespace EcsGame
{
    public sealed class EnemyFollowSystem : IEcsRunSystem
    {
        readonly EcsWorld m_world;
        readonly EcsFilter<Enemy, Follow> m_filter;

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
                
                var target_pos = follow.target.Get<TransformRef>().transform.position;
                enemy.navMeshAgent.SetDestination(target_pos);
                var enemy_tr = enemy.transform;
                var direction = (target_pos - enemy_tr.position).normalized;
                direction.y = 0f;
                enemy_tr.forward = direction;

                float sqr_dist = (enemy.transform.position - target_pos).sqrMagnitude;
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
