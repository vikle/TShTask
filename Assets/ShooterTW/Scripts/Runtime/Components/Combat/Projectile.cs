using UnityEngine;

namespace EcsGame
{
    public struct Projectile
    {
        public GameObject prefab;
        public GameObject gameObject;
        public Transform transform;
        public Vector3 direction;
        public Vector3 previousPos;
        public float speed;
        public float radius;
        public int damage;

        public void Deactivate() => InstantiatePool.DeSpawnObject(prefab, gameObject);
    };
}
