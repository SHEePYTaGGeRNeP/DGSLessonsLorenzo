using UnityEngine;
using Unity.Entities;
using Unity.Burst;
using Unity.Jobs;
using Unity.Transforms;
using Unity.Collections;
using Unity.Mathematics;

public class RotationSystem : JobComponentSystem
{
    // Use the [BurstCompile] attribute to compile a job with Burst. You may see significant speed ups, so try it!
    [BurstCompile]
    struct RotationSpeedJob : IJobForEach<Rotation, RotationSpeed_IJobEach>
    {
        public float DeltaTime;

        // The [ReadOnly] attribute tells the job scheduler that this job will not write to RotationSpeed
        public void Execute(ref Rotation rotation, [ReadOnly] ref RotationSpeed_IJobEach rotationComponent)
        {
            // Rotate something about its up vector at the speed given by RotationComponent.
            rotation.Value = math.mul(math.normalize(rotation.Value), quaternion.AxisAngle(math.up(), rotationComponent.radiansPerSecond * DeltaTime));
        }
    }

    // OnUpdate runs on the main thread.
    protected override JobHandle OnUpdate(JobHandle inputDependencies)
    {
        var job = new RotationSpeedJob
        {
            DeltaTime = Time.deltaTime
        };
        return job.Schedule(this, inputDependencies);
    }
}
