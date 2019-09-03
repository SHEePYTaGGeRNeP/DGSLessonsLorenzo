using Unity.Entities;
using UnityEngine;

namespace Assets.Scripts.ECS.Falling_Blocks
{
    [RequiresEntityConversion]
    public class PlayerAuthoring : MonoBehaviour, IConvertGameObjectToEntity
    {
        [SerializeField]
        private float _speed = 3;

        // The MonoBehaviour data is converted to ComponentData on the entity.
        // We are specifically transforming from a good editor representation of the data (Represented in degrees)
        // To a good runtime representation (Represented in radians)
        public void Convert(Entity entity, EntityManager dstManager, GameObjectConversionSystem conversionSystem)
        {
            var data = new PlayerComponent() { speed = _speed };
            dstManager.AddComponentData(entity, data);
        }
    }
}
