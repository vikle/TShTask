using Leopotam.Ecs;

namespace Client
{
    sealed class PlayerDeathSystem : IEcsRunSystem
    {
        readonly RuntimeData m_runtimeData;
        readonly UICanvas m_uiCanvas;
        EcsFilter<Player, DeathEvent> m_filter;

        void IEcsRunSystem.Run()
        {
            foreach (int i in m_filter)
            {
                ref var player = ref m_filter.Get1(i);
                player.gameObject.SetActive(false);
                
                m_runtimeData.gameOver = true;
                m_uiCanvas.ShowDeathScreen();
                m_filter.GetEntity(i).Destroy();
            }
        }
    };
}
