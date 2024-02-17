using Leopotam.Ecs;

namespace EcsGame
{
    public sealed class EnemyDeathSystem : IEcsRunSystem
    {
        readonly RuntimeData m_runtimeData;
        readonly UICanvas m_uiCanvas;
        readonly EcsFilter<Enemy, DeathEvent> m_filter;

        void IEcsRunSystem.Run()
        {
            foreach (int i in m_filter)
            {
                ref var enemy = ref m_filter.Get1(i);
                enemy.Die();

                ref var entity = ref m_filter.GetEntity(i);
                entity.Destroy();

                m_runtimeData.spawnedEnemies--;
                m_runtimeData.killedEnemies++;
                m_uiCanvas.hud.SetScores(m_runtimeData.killedEnemies);
            }
        }
    };
}
