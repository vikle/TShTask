using Leopotam.Ecs;
using UnityEngine;

namespace Client
{
    sealed class EnemyInitSystem : IEcsInitSystem
    {
        readonly EcsWorld m_world;
        readonly RuntimeData m_runtimeData;

        public void Init()
        {
            
            
            //m_runtimeData.spawnedEnemies++;
        }
    };
}
