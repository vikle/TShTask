using System.Collections.Generic;
using UnityEngine;

namespace EcsGame
{
    public static class InstantiatePool
    {
        static readonly Dictionary<GameObject, Stack<GameObject>> sr_pool = new Dictionary<GameObject, Stack<GameObject>>();
        static Transform s_pool;

        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterSceneLoad)]
        public static void Initialize() 
            => s_pool = new GameObject("InstantiatePool").transform;

        public static GameObject SpawnObject(GameObject original, in Vector3 position, in Quaternion rotation)
        {
            if (s_pool == null) Initialize();
            
            var clone = default(GameObject);

            if (sr_pool.TryGetValue(original, out var stack))
            {
                clone = (stack.Count > 0) ? stack.Pop() : null;
            }
            else
            {
                sr_pool[original] = new Stack<GameObject>();
            }

            if (clone == null) clone = Object.Instantiate(original);
            
            var tr = clone.transform;
            tr.SetParent(s_pool);
            tr.position = position;
            tr.rotation = rotation;
            clone.SetActive(true);

            return clone;
        }

        public static void DeSpawnObject(GameObject original, GameObject clone)
        {
            if (sr_pool.TryGetValue(original, out var stack) == false)
            {
                stack = new Stack<GameObject>();
                sr_pool[original] = stack;
            }
            
            stack.Push(clone);
            clone.gameObject.SetActive(false);
        }
    };
}
