using Leopotam.Ecs;

namespace Client
{
    sealed class EnemyDeathSystem : IEcsRunSystem
    {
        EcsFilter<Enemy, DeathEvent> m_deadEnemies;

        void IEcsRunSystem.Run()
        {
            foreach (int i in m_deadEnemies)
            {
                ref var enemy = ref m_deadEnemies.Get1(i);
                enemy.Die();
                
                ref var entity = ref m_deadEnemies.GetEntity(i);
                entity.Destroy();
            }
        }
    }
}
