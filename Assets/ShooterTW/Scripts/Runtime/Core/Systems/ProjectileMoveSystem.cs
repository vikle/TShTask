using Leopotam.Ecs;
using UnityEngine;

namespace Client
{
    sealed class ProjectileMoveSystem : IEcsRunSystem
    {
        EcsFilter<Projectile> m_filter;
    
        public void Run()
        {
            foreach (int i in m_filter)
            {
                ref var projectile = ref m_filter.Get1(i);
            
                var position = projectile.transform.position;
                position += projectile.direction * projectile.speed * Time.deltaTime;
                projectile.transform.position = position;
            
                var delta = position - projectile.previousPos;
                bool hit = Physics.SphereCast(projectile.previousPos, projectile.radius, delta.normalized, out var hit_info, delta.magnitude);
                
                if (hit)
                {
                    ref var entity = ref m_filter.GetEntity(i);
                    ref var projectile_hit = ref entity.Get<ProjectileHit>();
                    projectile_hit.raycastHit = hit_info;
                }

                projectile.previousPos = projectile.transform.position;
            }
        }
    }
}
