using Leopotam.Ecs;
using UnityEngine;

#if UNITY_EDITOR
using Leopotam.Ecs.UnityIntegration;
#endif

namespace EcsGame
{
    public sealed class EcsStartup : MonoBehaviour
    {
        public StaticData configuration;
        public SceneData sceneData;
        public UICanvas uiCanvas;

        EcsWorld m_world;
        EcsSystems m_updateSystems;

        void Start()
        {
            m_world = new EcsWorld();
            m_updateSystems = new EcsSystems(m_world);
#if UNITY_EDITOR
            EcsWorldObserver.Create(m_world);
            EcsSystemsObserver.Create(m_updateSystems);
#endif
            m_updateSystems
                .Add(new PlayerInitSystem())
                .Add(new PlayerInputSystem())
                .Add(new PlayerMoveSystem())
                .Add(new PlayerRotationSystem())
                .Add(new PlayerDeathSystem())
                .Add(new WeaponShootSystem())
                .Add(new SpawnProjectileSystem())
                .Add(new ProjectileMoveSystem())
                .Add(new ProjectileHitSystem())
                .Add(new ProjectileLifetimeSystem())
                .Add(new DamageSystem())
                .Add(new EnemySpawnSystem())
                .Add(new EnemyIdleSystem())
                .Add(new EnemyFollowSystem())
                .Add(new EnemyDeathSystem())
                .Inject(configuration)
                .Inject(sceneData)
                .Inject(uiCanvas)
                .Inject(new RuntimeData())
                .Init();
        }

        void Update()
            => m_updateSystems?.Run();

        void OnDestroy()
        {
            m_updateSystems?.Destroy();
            m_updateSystems = null;
            m_world?.Destroy();
            m_world = null;
        }
    };
}
