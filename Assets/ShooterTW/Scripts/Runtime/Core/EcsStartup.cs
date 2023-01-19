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
            
#if UNITY_EDITOR
            Leopotam.Ecs.UnityIntegration.EcsWorldObserver.Create(m_world);
            Leopotam.Ecs.UnityIntegration.EcsSystemsObserver.Create(m_updateSystems);
#endif
            m_updateSystems
                .Add (new PlayerInitSystem())
                .Add (new PlayerInitSystem())
                .Inject (configuration)
                .Inject (sceneData)
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
    }
}
