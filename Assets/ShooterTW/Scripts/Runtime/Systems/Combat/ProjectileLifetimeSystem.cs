using Leopotam.Ecs;
using UnityEngine;

namespace EcsGame
{
    public sealed class ProjectileLifetimeSystem : IEcsRunSystem
    {
        readonly EcsFilter<Projectile, ProjectileLifetime> m_filter;

        void IEcsRunSystem.Run()
        {
            foreach (int i in m_filter)
            {
                if(Time.time < m_filter.Get2(i).endTime) continue;
                m_filter.Get1(i).Deactivate();
                m_filter.GetEntity(i).Destroy();
            }
        }
    };
}
