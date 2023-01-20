using Leopotam.Ecs;
using UnityEngine;

namespace Client
{
    public class PlayerView : MonoBehaviour
    {
        public EcsEntity entity;

        public void Shoot()
        {
            entity.Get<HasWeapon>().current.Get<Shoot>();
        }
    };
}