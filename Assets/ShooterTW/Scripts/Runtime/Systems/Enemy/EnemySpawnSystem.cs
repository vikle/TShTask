using System;
using UnityEngine;
using Leopotam.Ecs;
using Random = UnityEngine.Random;

namespace EcsGame
{
    public sealed class EnemySpawnSystem : IEcsRunSystem
    {
        readonly EcsWorld m_world;
        readonly StaticData m_staticData;
        readonly RuntimeData m_runtimeData;
        readonly EcsFilter<SpawnEnemy> m_filter;

        void IEcsRunSystem.Run()
        {
            if (m_runtimeData.gameOver) return;
            
            foreach (int i in m_filter)
            {
                var enemy_entity = m_world.NewEntity();
                ref var enemy = ref enemy_entity.Get<Enemy>();
                ref var health = ref enemy_entity.Get<Health>();

                var enemy_prefab = m_staticData.GetRandomEnemyPrefab();
                var spawn_pos = RandomPointOnCircle(m_staticData.enemySpawnDistance);
                var enemy_clone = InstantiatePool.SpawnObject(enemy_prefab, spawn_pos, Quaternion.identity);
                var enemy_view = enemy_clone.GetComponent<EnemyView>();
                enemy.gameObject = enemy_clone;
                enemy.transform = enemy_clone.transform;

                enemy.navMeshAgent = enemy_view.navMeshAgent;
                enemy.damage = enemy_view.damage;
                enemy.meleeAttackDistance = enemy_view.meleeAttackDistance;
                enemy.meleeAttackInterval = enemy_view.meleeAttackInterval;
                enemy.triggerDistance = enemy_view.triggerDistance;
                enemy_view.entity = enemy_entity;
                enemy.startPosition = spawn_pos;
                
                health.shield = enemy_view.startShield;
                health.value = enemy_view.startHealth;

                enemy_entity.Get<Idle>();

                m_filter.GetEntity(i).Destroy();
            }

            if (m_runtimeData.spawnedEnemies >= m_staticData.maxEnemies) return;
            m_runtimeData.spawnedEnemies++;
            m_world.NewEntity().Get<SpawnEnemy>();
        }

        static Vector3 RandomPointOnCircle(float radius)
        {
            float angle = Random.value * (MathF.PI * 2f);
            return new Vector3
            {
                x = MathF.Sin(angle) * radius,
                z = MathF.Cos(angle) * radius
            };
        }
    };
}
