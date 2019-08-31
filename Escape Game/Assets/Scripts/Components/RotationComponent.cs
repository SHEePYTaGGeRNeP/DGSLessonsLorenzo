using System;
using Unity.Entities;

[Serializable]
public struct RotationSpeed : IComponentData
{
    public float radiansPerSecond;
}
public class RotationSpeedComponent : ComponentDataProxy<RotationSpeed> { }
