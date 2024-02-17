using Leopotam.Ecs;
using UnityEngine;

namespace EcsGame
{
    public sealed class PlayerRotationSystem : IEcsRunSystem
    {
        readonly EcsFilter<Player> m_filter;
        readonly SceneData m_sceneData;

        void IEcsRunSystem.Run()
        {
            foreach (int i in m_filter)
            {
                ref var player = ref m_filter.Get1(i);
                var player_plane = new Plane(Vector3.up, player.transform.position);
                var ray = m_sceneData.mainCamera.ScreenPointToRay(Input.mousePosition);
                if (player_plane.Raycast(ray, out float hit) == false) continue;
                player.transform.forward = ray.GetPoint(hit) - player.transform.position;
            }
        }
    };
}
