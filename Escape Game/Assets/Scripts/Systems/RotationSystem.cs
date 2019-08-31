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
    struct RotationSpeedJob : IJobForEach<Rotation, RotationSpeed>
    {
        public float DeltaTime;

        // The [ReadOnly] attribute tells the job scheduler that this job will not write to rotSpeedIJobForEach
        public void Execute(ref Rotation rotation, [ReadOnly] ref RotationSpeed rotationComponent)
        {
            // Rotate something about its up vector at the speed given by RotationComponent.
            rotation.Value = math.mul(math.normalize(rotation.Value), quaternion.AxisAngle(math.up(), rotationComponent.radiansPerSecond * DeltaTime));
        }
    }

    // Use the [BurstCompile] attribute to compile a job with Burst. You may see significant speed ups, so try it!
    [BurstCompile]
    struct RotationSpeedJobParallel : IJobParallelFor
    {
        public float DeltaTime;
        public Rotation Rotation;
        public float RadiansPerSecond;

        public void Execute(int index)
        {
            Rotation.Value = math.mul(math.normalize(Rotation.Value), quaternion.AxisAngle(math.up(), RadiansPerSecond * DeltaTime));
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
