using Leopotam.Ecs;
using UnityEngine;

namespace Client
{
    sealed class EcsStartup : MonoBehaviour
    {
        public StaticData configuration;
        public SceneData sceneData;

        EcsWorld m_world;
        EcsSystems m_updateSystems;

        void Start()
        {
            m_world = new EcsWorld();
            m_updateSystems = new EcsSystems(m_world);
            var runtime_data = new RuntimeData();
#if UNITY_EDITOR
            Leopotam.Ecs.UnityIntegration.EcsWorldObserver.Create(m_world);
            Leopotam.Ecs.UnityIntegration.EcsSystemsObserver.Create(m_updateSystems);
#endif
            m_updateSystems
                .Add(new PlayerInitSystem())
                .Add(new PlayerInputSystem())
                .Add(new PlayerMoveSystem())
                .Add(new PlayerRotationSystem())
                //.Add(new PlayerDeathSystem())
                .Add(new WeaponShootSystem())
                .Add(new SpawnProjectileSystem())
                .Add(new ProjectileMoveSystem())
                .Add(new ProjectileHitSystem())
                //.Add(new DamageSystem())
                //.Add(new EnemyInitSystem())
                //.Add(new EnemyIdleSystem())
                //.Add(new EnemyFollowSystem())
                //.Add(new EnemyDeathSystem())
                //.Add(new PauseSystem())
                .Inject(configuration)
                .Inject(sceneData)
                .Inject(runtime_data)
                .Init();
        }

        void Update()
        {
            m_updateSystems?.Run();
        }

        void OnDestroy()
        {
            m_updateSystems?.Destroy();
            m_updateSystems = null;
            m_world?.Destroy();
            m_world = null;
        }
    };
}
