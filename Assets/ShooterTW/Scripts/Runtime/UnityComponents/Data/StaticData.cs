using System.Collections.Generic;
using UnityEngine;

namespace EcsGame
{
    [CreateAssetMenu]
    public sealed class StaticData : ScriptableObject
    {
        [Header("Player")]
        public GameObject playerPrefab;
        public float playerShield = 0.3f;
        public int playerHealth = 100;
        public float playerSpeed = 3f;
        
        [Header("Camera")]
        public float smoothTime = 0.3f;
        public Vector3 followOffset = new(0f, 10f, -6f);
        
        [Header("Enemies")]
        public int maxEnemies = 100;
        public float enemySpawnDistance = 10f;
        public List<GameObject> prefabs = new();

        public GameObject GetRandomEnemyPrefab() => prefabs.Count != 0 
            ? prefabs[Random.Range(0, prefabs.Count)] 
            : null;
    };
}
