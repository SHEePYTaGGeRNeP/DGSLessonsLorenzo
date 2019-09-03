using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Jobs;

namespace Assets.Scripts.ECS.JobParellelFor
{
    public struct RotationSpeed_ParallelFor : IJobParallelForTransform
    {
        public float rotationSpeed;
        public float deltaTime;

        public void Execute(int index, TransformAccess transform)
        {
            Quaternion newRot = math.mul(math.normalize(transform.localRotation), quaternion.AxisAngle(math.up(), rotationSpeed * deltaTime));
            transform.rotation = newRot;
        }
    }
}
