using System.Collections.Generic;
using UnityEngine;

namespace Client
{
    [CreateAssetMenu]
    public class StaticData : ScriptableObject
    {
        [Header("Player")]
        public GameObject playerPrefab;
        public float playerShield = .3f;
        public int playerHealth = 100;
        public float playerSpeed = 3f;
        
        [Header("Enemies")]
        public int maxEnemies = 100;
        public float enemySpawnDistance = 10f;
        public List<GameObject> prefabs = new List<GameObject>();

        public GameObject GetRandomEnemyPrefab() => prefabs.Count != 0 
            ? prefabs[Random.Range(0, prefabs.Count)] 
            : null;
    };
}
