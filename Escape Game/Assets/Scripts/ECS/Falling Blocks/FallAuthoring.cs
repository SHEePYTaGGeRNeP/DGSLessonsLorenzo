using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity.Entities;
using UnityEngine;

namespace Assets.Scripts.ECS.Falling_Blocks
{
    [RequiresEntityConversion]
    public class FallAuthoring : MonoBehaviour, IConvertGameObjectToEntity
    {
        public float _speed = 1;

        // The MonoBehaviour data is converted to ComponentData on the entity.
        // We are specifically transforming from a good editor representation of the data (Represented in degrees)
        // To a good runtime representation (Represented in radians)
        public void Convert(Entity entity, EntityManager dstManager, GameObjectConversionSystem conversionSystem)
        {
            var data = new FallComponent { speed = this._speed };
            dstManager.AddComponentData(entity, data);
        }
    }
}
