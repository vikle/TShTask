using UnityEngine;

namespace Client
{
    public struct Projectile
    {
        public Vector3 direction;
        public Vector3 previousPos;
        public GameObject projectileGO;
        public float speed;
        public float radius;
        public int damage;
    };
}
