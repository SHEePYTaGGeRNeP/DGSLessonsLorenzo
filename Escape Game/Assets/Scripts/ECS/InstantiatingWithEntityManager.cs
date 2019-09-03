using Unity.Mathematics;
using UnityEngine;
using Unity.Entities;
using Unity.Collections;
using Unity.Transforms;

namespace Assets.Scripts.ECS
{
    class InstantiatingWithEntityManager : MonoBehaviour
    {
        [SerializeField]
        private GameObject _prefab;
        
        private void Start()
        {
            this.Spawn(3);
        }

        private void Spawn(int amount)
        {
            var prefab = GameObjectConversionUtility.ConvertGameObjectHierarchy(_prefab, World.Active);
            
            NativeArray<Entity> entities = new NativeArray<Entity>(amount, Allocator.Temp);
            EntityManager em = World.Active.EntityManager;
            em.Instantiate(prefab, entities);
            for (int i = 0; i < amount; i++)
            {
                em.SetComponentData(entities[i], new Translation { Value = new float3(R(), R(), R()) });
            }

            // Native arrays must be disposed manually
            entities.Dispose();
        }

        private float R() => UnityEngine.Random.Range(-2f, 2f);

        private void Update()
        {
            if (Input.GetKeyDown("space"))
                this.Spawn(1);
        }
    }
}
