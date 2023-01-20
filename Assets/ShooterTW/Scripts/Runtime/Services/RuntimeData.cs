using Leopotam.Ecs;

namespace Client
{
    public sealed class RuntimeData
    {
        public bool gameOver;
        public EcsEntity playerEntity;
        public int spawnedEnemies;
        public int killedEnemies;
    };
}
