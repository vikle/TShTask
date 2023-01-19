using UnityEngine;
using Leopotam.Ecs;

namespace Client
{
    public class PlayerInitSystem : IEcsInitSystem
    {
        readonly EcsWorld m_world;
        readonly StaticData m_staticData;
        readonly SceneData m_sceneData;
        readonly RuntimeData m_runtimeData;

        public void Init()
        {
            var player_entity = m_world.NewEntity();
            var weapon_entity = m_world.NewEntity();
            
            ref var player = ref player_entity.Get<Player>();
            ref var input_data = ref player_entity.Get<PlayerInputData>();
            ref var transform_ref = ref player_entity.Get<TransformRef>();
            ref var health = ref player_entity.Get<Health>();
            ref var weapon = ref weapon_entity.Get<Weapon>();

            var player_go = Object.Instantiate(m_staticData.playerPrefab, m_sceneData.playerSpawnPoint.position, Quaternion.identity);
            player.transform = player_go.transform;
            player.controller = player_go.GetComponent<CharacterController>();
            player.playerSpeed = m_staticData.playerSpeed;

            var weapon_view = player_go.GetComponent<WeaponSettings>();
            
            weapon.owner = player_entity;
            weapon.projectilePrefab = weapon_view.projectilePrefab;
            weapon.projectileRadius = weapon_view.projectileRadius;
            weapon.projectileSocket = weapon_view.projectileSocket;
            weapon.projectileSpeed = weapon_view.projectileSpeed;
            weapon.weaponDamage = weapon_view.weaponDamage;

            player_go.GetComponent<PlayerView>().entity = player_entity;
            
            health.value = m_staticData.playerHealth;
            transform_ref.transform = player_go.transform;
            m_runtimeData.playerEntity = player_entity;
        }
    };
}


