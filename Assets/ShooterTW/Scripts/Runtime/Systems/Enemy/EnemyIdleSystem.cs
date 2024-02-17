using Leopotam.Ecs;

namespace EcsGame
{
    public sealed class EnemyIdleSystem : IEcsRunSystem
    {
        readonly EcsFilter<Enemy, Idle> m_calmEnemies;
        readonly RuntimeData m_runtimeData;

        void IEcsRunSystem.Run()
        {
            foreach (int i in m_calmEnemies)
            {
                ref var enemy = ref m_calmEnemies.Get1(i);
                var player_pos = m_runtimeData.playerEntity.Get<Player>().transform.position;
                float sqr_dist = (enemy.transform.position - player_pos).sqrMagnitude;
                float t_dist = enemy.triggerDistance;
                float t_sqr_dist = (t_dist * t_dist);

                if (sqr_dist > t_sqr_dist) continue;
                
                ref var entity = ref m_calmEnemies.GetEntity(i);
                entity.Del<Idle>();
                ref var follow = ref entity.Get<Follow>();
                follow.target = m_runtimeData.playerEntity;
            }
        }
    };
}
