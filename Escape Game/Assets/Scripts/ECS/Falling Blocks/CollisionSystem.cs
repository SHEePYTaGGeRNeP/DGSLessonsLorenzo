using System;
using Unity.Burst;
using Unity.Collections;
using Unity.Entities;
using Unity.Jobs;
using UnityEngine;

namespace Assets.Scripts.ECS.Falling_Blocks
{
    class CollisionSystem : JobComponentSystem
    {
        // Use the [BurstCompile] attribute to compile a job with Burst. You may see significant speed ups, so try it!
        [BurstCompile]
        struct CollisionComponentJob : IJobForEach<CollisionComponent>
        {
            //public EntityManager em;

            // The [ReadOnly] attribute tells the job scheduler that this job will not write to RotationSpeed
            public void Execute([ReadOnly] ref CollisionComponent collComponent)
            {
                //Debug.Log($"collision between: {collComponent.source} and {collComponent.other}");
                //bool oneIsBlock = em.HasComponent<BlockComponent>(collComponent.source)
                //    || em.HasComponent<BlockComponent>(collComponent.other);
                //if (!oneIsBlock)
                //    return;
                //Debug.Log($"One of them is a block");
                //bool oneIsPlayer = em.HasComponent<PlayerComponent>(collComponent.source)
                //    || em.HasComponent<PlayerComponent>(collComponent.other);
                //if (oneIsPlayer && oneIsBlock)
                //{
                //    throw new Exception("Game over!");
                //}
                //Debug.Log($"Destroying block");
                //Entity block = em.HasComponent<BlockComponent>(collComponent.source) ?
                //    collComponent.source : collComponent.other;
                
                //em.DestroyEntity(block);
            }
        }

        // OnUpdate runs on the main thread.
        protected override JobHandle OnUpdate(JobHandle inputDependencies)
        {
            var job = new CollisionComponentJob();
            //{
            //    em = World.Active.EntityManager
            //};
            return job.Schedule(this, inputDependencies);
        }
    }
}
