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
                    m_filter.GetEntity(i).Del<Follow>();
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
                float attack_dist = enemy.meleeAttackDistance;
                float sqr_attack_dist = (attack_dist * attack_dist);
                if (sqr_dist > sqr_attack_dist) continue;
                if (Time.time < follow.nextAttackTime) continue;
                follow.nextAttackTime = (Time.time + enemy.meleeAttackInterval);
                ref var dmg_evt = ref m_world.NewEntity().Get<DamageEvent>();
                dmg_evt.target = follow.target;
                dmg_evt.value = enemy.damage;
            }
        }
    };
}
