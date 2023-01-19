using UnityEngine;
using Leopotam.Ecs;

namespace Client
{
    public class PlayerInitSystem : IEcsInitSystem
    {
        readonly EcsWorld m_world;


        public void Init()
        {
            var player_entity = m_world.NewEntity();

            ref var player = ref player_entity.Get<Player>();
            ref var input_data = ref player_entity.Get<PlayerInputData>();

            //player.controller = // где же взять Rigidbody игрока?
        }




    };
}


