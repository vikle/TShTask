using Leopotam.Ecs;

namespace Client
{
    public struct Follow
    {
        public EcsEntity target;
        public float nextAttackTime;
    }
}