using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity.Burst;
using Unity.Collections;
using Unity.Entities;
using Unity.Jobs;
using Unity.Transforms;
using UnityEngine;

namespace Assets.Scripts.ECS.Falling_Blocks
{
    class FallSystem : JobComponentSystem
    {
        // Use the [BurstCompile] attribute to compile a job with Burst. You may see significant speed ups, so try it!
        [BurstCompile]
        struct FallComponentJob : IJobForEach<Translation, FallComponent>
        {
            public float DeltaTime;

            // The [ReadOnly] attribute tells the job scheduler that this job will not write to RotationSpeed
            public void Execute(ref Translation translation, [ReadOnly] ref FallComponent fallComponent)
            {
                // Rotate something about its up vector at the speed given by RotationComponent.
                //translation.Value += new Unity.Mathematics.float3(0, -(fallComponent.speed) * DeltaTime, 0);
            }
        }

        // OnUpdate runs on the main thread.
        protected override JobHandle OnUpdate(JobHandle inputDependencies)
        {
            var job = new FallComponentJob
            {
                DeltaTime = Time.deltaTime
            };
            return job.Schedule(this, inputDependencies);
        }
    }
    }
