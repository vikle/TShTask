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
                ref var time = ref m_filter.Get2(i);
                if(Time.time < time.endTime) continue;
                
                ref var projectile = ref m_filter.Get1(i);
                projectile.Deactivate();
                m_filter.GetEntity(i).Destroy();
            }
        }
    };
}
