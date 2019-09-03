using Unity.Entities;
using UnityEngine;

namespace Assets.Scripts.ECS.Falling_Blocks
{
    [RequiresEntityConversion]
    public class BlockAuthoring : MonoBehaviour, IConvertGameObjectToEntity
    {
        // The MonoBehaviour data is converted to ComponentData on the entity.
        // We are specifically transforming from a good editor representation of the data (Represented in degrees)
        // To a good runtime representation (Represented in radians)
        public void Convert(Entity entity, EntityManager dstManager, GameObjectConversionSystem conversionSystem)
        {
            var data = new BlockComponent();
            dstManager.AddComponentData(entity, data);
        }
    }
}
