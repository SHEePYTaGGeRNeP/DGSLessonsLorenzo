using System;
using Unity.Entities;
using UnityEngine;

namespace Assets.Scripts.ECS.Falling_Blocks
{
    class FallingBlockCollision : MonoBehaviour
    {
        private void OnCollisionEnter(Collision collision)
        {
            Debug.Log("Collision!");
            GameObjectEntity otherGameObjectEntity = collision.transform.GetComponent<GameObjectEntity>();
            if (!otherGameObjectEntity)
            {
                return;
            }
            Entity sourceEntity = GetComponent<GameObjectEntity>().Entity;
            Entity otherEntity = otherGameObjectEntity.Entity;
            var em = World.Active.EntityManager;
            //Entity collisionEventEntity = entityManager.CreateEntity(typeof(CollisionComponent));
            //entityManager.SetComponentData(collisionEventEntity, new CollisionComponent
            //{
            //    source = sourceEntity,
            //    other = otherGameObjectEntity.Entity,
            //});
            bool oneIsBlock = em.HasComponent<BlockComponent>(sourceEntity)
                    || em.HasComponent<BlockComponent>(otherEntity);
            if (!oneIsBlock)
                return;
            Debug.Log($"One of them is a block");
            bool oneIsPlayer = em.HasComponent<PlayerComponent>(sourceEntity)
                || em.HasComponent<PlayerComponent>(otherEntity);
            if (oneIsPlayer && oneIsBlock)
            {
                throw new Exception("Game over!");
            }
            Entity block = em.HasComponent<BlockComponent>(sourceEntity) ?
                    sourceEntity : otherEntity;

            em.DestroyEntity(block);
        }
    }
}
