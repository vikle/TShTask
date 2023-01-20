using Leopotam.Ecs;
using UnityEngine;

namespace Client
{
    sealed class PlayerInputSystem : IEcsRunSystem
    {
        EcsFilter<PlayerInputData, HasWeapon> m_filter;

        void IEcsRunSystem.Run()
        {
            foreach (int i in m_filter)
            {
                ref var input = ref m_filter.Get1(i);
                input.moveInput = new Vector3(Input.GetAxisRaw("Horizontal"), 0f, Input.GetAxisRaw("Vertical"));

                if (Input.GetMouseButtonDown(0))
                {
                    ref var has_weapon = ref m_filter.Get2(i);
                    has_weapon.current.Get<Shoot>();
                }
            }
        }
    };
}
