using Leopotam.Ecs;

namespace Client
{
    sealed class ProjectileHitSystem : IEcsRunSystem
    {
        EcsFilter<Projectile, ProjectileHit> m_filter;
        EcsWorld m_world;

        public void Run()
        {
            foreach (int i in m_filter)
            {
                ref var projectile = ref m_filter.Get1(i);
                ref var hit = ref m_filter.Get2(i);

                if (hit.raycastHit.collider.TryGetComponent(out EnemyView enemy_view))
                {
                    if (enemy_view.entity.IsAlive())
                    {
                        ref var dmg_ev = ref m_world.NewEntity().Get<DamageEvent>();
                        dmg_ev.target = enemy_view.entity;
                        dmg_ev.value = projectile.damage;
                    }
                }

                projectile.projectileGO.SetActive(false);
                m_filter.GetEntity(i).Destroy();
            }
        }
    };
}
