using UnityEngine;

namespace Client
{
    [CreateAssetMenu]
    public class StaticData : ScriptableObject
    {
        public GameObject playerPrefab;
        public float playerSpeed = 1f;
        
        
    };
}
