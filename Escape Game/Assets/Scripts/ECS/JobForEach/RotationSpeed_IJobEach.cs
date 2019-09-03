using System;
using Unity.Entities;

[Serializable]
public struct RotationSpeed_IJobEach : IComponentData
{
    public float radiansPerSecond;
}