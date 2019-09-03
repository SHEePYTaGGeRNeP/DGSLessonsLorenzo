using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity.Burst;
using Unity.Collections;
using Unity.Entities;
using Unity.Jobs;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;

namespace Assets.Scripts.ECS.Falling_Blocks
{
    class PlayerInputMovementSystem : JobComponentSystem
    {
        // Use the [BurstCompile] attribute to compile a job with Burst. You may see significant speed ups, so try it!
        [BurstCompile]
        struct FallComponentJob : IJobForEach<Translation, PlayerComponent>
        {
            public float DeltaTime;
            public float2 Input;

            // The [ReadOnly] attribute tells the job scheduler that this job will not write to RotationSpeed
            public void Execute(ref Translation translation, [ReadOnly] ref PlayerComponent playerComponent)
            {
                // Rotate something about its up vector at the speed given by RotationComponent.
                translation.Value += new float3(Input.x * DeltaTime * playerComponent.speed, Input.y * DeltaTime * playerComponent.speed, 0);
            }
        }

        // OnUpdate runs on the main thread.
        protected override JobHandle OnUpdate(JobHandle inputDependencies)
        {
            var job = new FallComponentJob
            {
                DeltaTime = Time.deltaTime,
                Input = new float2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"))
            };
            return job.Schedule(this, inputDependencies);
        }
    }
}
