using Leopotam.Ecs;
using UnityEngine;

namespace EcsGame
{
    public sealed class CameraFollowSystem : IEcsRunSystem
    {
        readonly EcsFilter<Player> m_filter;
        readonly SceneData m_sceneData;
        readonly StaticData m_staticData;
        
        Vector3 m_currentVelocity;

        void IEcsRunSystem.Run()
        {
            foreach (int i in m_filter)
            {
                var player_pos = m_filter.Get1(i).transform.position;
                var cam_tr = m_sceneData.mainCameraTransform;
                var target_pos = (player_pos + m_staticData.followOffset);
                cam_tr.position = Vector3.SmoothDamp(cam_tr.position, target_pos, ref m_currentVelocity, m_staticData.smoothTime);
            }
        }
    }
}
