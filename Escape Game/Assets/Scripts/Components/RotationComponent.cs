using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;

[Serializable]
public class RotationComponent : MonoBehaviour, IComponentData
{
    public float radiansPerSecond;
}
