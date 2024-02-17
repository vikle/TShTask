using Leopotam.Ecs;

namespace EcsGame
{
    public struct HasWeapon
    {
        public EcsEntity current;
        public float nextFireTime;
    };
}
