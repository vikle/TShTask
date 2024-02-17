using Leopotam.Ecs;
using UnityEngine;

namespace EcsGame
{
    public sealed class DamageSystem : IEcsRunSystem
    {
        readonly UICanvas m_uiCanvas;
        readonly EcsFilter<DamageEvent> m_filter;
    
        public void Run()
        {
            foreach (int i in m_filter)
            {
                ref var dmg = ref m_filter.Get1(i);
                ref var health = ref dmg.target.Get<Health>();

                health.value -= (dmg.value * (1f - health.shield));

                if (health.value <= 0)
                {
                    dmg.target.Get<DeathEvent>();
                }

                if (dmg.target.Has<Player>())
                {
                    m_uiCanvas.hud.SetHealth((int)health.value);
                }

                m_filter.GetEntity(i).Destroy();
            }
        }
    }
}
