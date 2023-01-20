using Leopotam.Ecs;

namespace Client
{
    sealed class EnemyFollowSystem : IEcsRunSystem
    {
        EcsFilter<Enemy, Follow> m_followingEnemies;
        readonly EcsWorld m_world;

        void IEcsRunSystem.Run()
        {
            foreach (int i in m_followingEnemies)
            {
                ref var enemy = ref m_followingEnemies.Get1(i);
                ref var follow = ref m_followingEnemies.Get2(i);
                
                if (follow.target.IsAlive() == false)
                {
                    ref var entity = ref m_followingEnemies.GetEntity(i);
                    entity.Del<Follow>();
                    continue;
                }
                
                ref var transform_ref = ref follow.target.Get<TransformRef>();
                var target_pos = transform_ref.transform.position;
                enemy.navMeshAgent.SetDestination(target_pos);
                var e_tr = enemy.transform;
                var direction = (target_pos - e_tr.position).normalized;
                direction.y = 0f;
                e_tr.forward = direction;
                
                
                
            }
        }
    };
}
