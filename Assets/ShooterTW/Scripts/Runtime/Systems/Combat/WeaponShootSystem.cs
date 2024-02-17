using Leopotam.Ecs;

namespace EcsGame
{
    public sealed class WeaponShootSystem : IEcsRunSystem
    {
        readonly EcsFilter<Weapon, Shoot> m_filter;

        void IEcsRunSystem.Run()
        {
            foreach (int i in m_filter)
            {
                ref var weapon = ref m_filter.Get1(i);

                ref var entity = ref m_filter.GetEntity(i);
                entity.Del<Shoot>();
            
                ref var spawn_projectile = ref entity.Get<SpawnProjectile>();
            }
        }
    };
}
