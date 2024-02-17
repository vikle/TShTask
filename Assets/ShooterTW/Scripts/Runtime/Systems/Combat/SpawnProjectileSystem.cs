using UnityEngine;
using Leopotam.Ecs;

namespace EcsGame
{
    public sealed class SpawnProjectileSystem : IEcsRunSystem
    {
        readonly EcsWorld m_world;
        EcsFilter<Weapon, SpawnProjectile> m_filter;

        void IEcsRunSystem.Run()
        {
            foreach (int i in m_filter)
            {
                ref var weapon = ref m_filter.Get1(i);
                var projectile_go = InstantiatePool.SpawnObject(weapon.projectilePrefab, weapon.projectileSocket.position, Quaternion.identity);
                var projectile_entity = m_world.NewEntity();
                
                ref var projectile = ref projectile_entity.Get<Projectile>();
                projectile.prefab = weapon.projectilePrefab;
                projectile.gameObject = projectile_go;
                projectile.transform = projectile_go.transform;
                projectile.damage = weapon.weaponDamage;
                projectile.direction = weapon.projectileSocket.forward;
                projectile.radius = weapon.projectileRadius;
                projectile.speed = weapon.projectileSpeed;
                projectile.previousPos = projectile_go.transform.position;
                
                ref var projectile_lifetime = ref projectile_entity.Get<ProjectileLifetime>();
                projectile_lifetime.endTime = weapon.projectileLifetime + Time.time;

                ref var entity = ref m_filter.GetEntity(i);
                entity.Del<SpawnProjectile>();
            }
        }
    };
}
