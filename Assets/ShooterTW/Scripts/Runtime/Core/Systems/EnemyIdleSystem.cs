using Leopotam.Ecs;
using UnityEngine;

namespace Client
{
    sealed class EnemyIdleSystem : IEcsRunSystem
    {
        EcsFilter<Enemy, Idle> m_calmEnemies;
        readonly RuntimeData m_runtimeData;

        void IEcsRunSystem.Run()
        {
            foreach (int i in m_calmEnemies)
            {
                ref var enemy = ref m_calmEnemies.Get1(i);
                ref var player = ref m_runtimeData.playerEntity.Get<Player>();

                if ((enemy.transform.position - player.transform.position).sqrMagnitude <= enemy.triggerDistance * enemy.triggerDistance)
                {
                    ref var entity = ref m_calmEnemies.GetEntity(i);
                    entity.Del<Idle>();
                    ref var follow = ref entity.Get<Follow>();
                    follow.target = m_runtimeData.playerEntity;
                }
            }
        }
    };
}
