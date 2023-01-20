using UnityEngine;

namespace Client
{
    public struct Player
    {
        public GameObject gameObject;
        public Transform transform;
        public CharacterController controller;
        public float playerSpeed;
    };
}
