using Unity.Entities;

namespace Assets.Scripts.ECS.Falling_Blocks
{
    struct CollisionComponent : IComponentData
    {
        public Entity source;
        public Entity other;
    }
}
