using Leopotam.Ecs;
using UnityEngine;

namespace EcsGame
{
    public sealed class PlayerInputSystem : IEcsRunSystem
    {
        readonly RuntimeData m_runtimeData;
        readonly EcsFilter<PlayerInputData, HasWeapon> m_filter;

        void IEcsRunSystem.Run()
        {
            if (m_runtimeData.gameOver) return;
            
            foreach (int i in m_filter)
            {
                ref var input = ref m_filter.Get1(i);
                input.moveInput = new Vector3(Input.GetAxisRaw("Horizontal"), 0f, Input.GetAxisRaw("Vertical"));

                if (Input.GetMouseButton(0))
                {
                    ref var has_weapon = ref m_filter.Get2(i);
                    if (has_weapon.nextFireTime <= Time.time)
                    {
                        ref var weapon = ref has_weapon.current.Get<Weapon>();
                        has_weapon.nextFireTime = weapon.fireInterval + Time.time;
                        has_weapon.current.Get<Shoot>();
                    }
                }
            }
        }
    };
}
