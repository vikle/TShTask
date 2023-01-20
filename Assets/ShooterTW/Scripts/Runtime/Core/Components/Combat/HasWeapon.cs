using Leopotam.Ecs;

namespace Client
{
    public struct HasWeapon
    {
        public EcsEntity current;
        public float nextFireTime;
    };
}
