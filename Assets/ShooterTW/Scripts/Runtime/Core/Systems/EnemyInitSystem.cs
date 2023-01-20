using Leopotam.Ecs;
using UnityEngine;

namespace Client
{
    sealed class EnemyInitSystem : IEcsInitSystem
    {
        readonly EcsWorld m_world;

        public void Init()
        {
            foreach (var enemy_view in Object.FindObjectsOfType<EnemyView>())
            {
                var enemy_entity = m_world.NewEntity();
                ref var enemy = ref enemy_entity.Get<Enemy>();
                ref var health = ref enemy_entity.Get<Health>();

                enemy.gameObject = enemy_view.gameObject;
                enemy.transform = enemy_view.transform;
                enemy.navMeshAgent = enemy_view.navMeshAgent;
                enemy.damage = enemy_view.damage;
                enemy.meleeAttackDistance = enemy_view.meleeAttackDistance;
                enemy.meleeAttackInterval = enemy_view.meleeAttackInterval;
                enemy.triggerDistance = enemy_view.triggerDistance;
                enemy_view.entity = enemy_entity;
                
                health.value = enemy_view.startHealth;
                
                enemy_entity.Get<Idle>();
            }
        }
    };
}
