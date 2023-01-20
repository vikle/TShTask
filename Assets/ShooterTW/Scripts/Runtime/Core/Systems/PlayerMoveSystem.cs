using Leopotam.Ecs;
using UnityEngine;

namespace Client
{
    sealed class PlayerMoveSystem : IEcsRunSystem
    {
        EcsFilter<Player, PlayerInputData> m_filter;

        public void Run()
        {
            foreach (int i in m_filter)
            {
                ref var player = ref m_filter.Get1(i);
                ref var input = ref m_filter.Get2(i);
                var direction = (Vector3.forward * input.moveInput.z + Vector3.right * input.moveInput.x).normalized;
                var force = (direction * player.playerSpeed);
                player.controller.Move(force * Time.deltaTime);
            }
        }
    };
}
