using Leopotam.Ecs;

namespace Client
{
    sealed class DamageSystem : IEcsRunSystem
    {
        EcsFilter<DamageEvent> m_damageEvents;
    
        public void Run()
        {
            foreach (int i in m_damageEvents)
            {
                ref var e = ref m_damageEvents.Get1(i);
                ref var health = ref e.target.Get<Health>();

                health.value -= e.value;

                if (health.value <= 0)
                {
                    e.target.Get<DeathEvent>();
                }

                m_damageEvents.GetEntity(i).Destroy();
            }
        }
    }
}
