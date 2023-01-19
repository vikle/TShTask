using UnityEngine;

namespace Client
{
    [CreateAssetMenu]
    public class StaticData : ScriptableObject
    {
        public GameObject playerPrefab;
        public int playerHealth = 100;
        public float playerSpeed = 3f;
    };
}
