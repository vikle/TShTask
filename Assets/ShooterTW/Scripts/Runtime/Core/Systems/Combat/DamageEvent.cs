using Leopotam.Ecs;

namespace Client
{
    public struct DamageEvent
    {
        public EcsEntity target;
        public int value;
    };
}
