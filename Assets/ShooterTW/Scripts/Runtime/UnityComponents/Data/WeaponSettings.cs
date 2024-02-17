using UnityEngine;

namespace EcsGame
{
    public class WeaponSettings : MonoBehaviour
    {
        public GameObject projectilePrefab;
        public Transform projectileSocket;
        public float fireInterval = .2f;
        public int weaponDamage;
        public float projectileSpeed;
        public float projectileRadius;
        public float projectileLifetime;
    };
}
