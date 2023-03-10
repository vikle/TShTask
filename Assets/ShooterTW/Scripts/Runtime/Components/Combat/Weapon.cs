using Leopotam.Ecs;
using UnityEngine;

namespace Client
{
    public struct Weapon
    {
        public EcsEntity owner;
        public GameObject projectilePrefab;
        public Transform projectileSocket;
        public float fireInterval;
        public float projectileSpeed;
        public float projectileRadius;
        public float projectileLifetime;
        public int weaponDamage;
    };
}
