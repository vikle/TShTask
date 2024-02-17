using Leopotam.Ecs;

namespace EcsGame
{
    public struct DamageEvent
    {
        public EcsEntity target;
        public int value;
    };
}
