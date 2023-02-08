using Unity.Entities;
using Unity.Burst;
using Unity.Collections;
using Unity.Mathematics;
using Unity.Transforms;

[BurstCompile]
[UpdateInGroup(typeof(InitializationSystemGroup))]
public partial struct ECSSystem : ISystem
{

    EntityQuery m_SheepObjects;
    uint m_UpdateCounter;

    [BurstCompile]
    public void OnCreate(ref SystemState state)
    {
        state.RequireForUpdate<ECSEntity>();

        var queryBuilder = new EntityQueryBuilder(Allocator.Temp);
        queryBuilder.WithAll<sheepID>();
        m_SheepObjects = state.GetEntityQuery(queryBuilder);
    }

    [BurstCompile]
    public void OnDestroy(ref SystemState state)
    {
         
    }

    [BurstCompile]
    public void OnUpdate(ref SystemState state)
    {
        if (m_SheepObjects.IsEmpty)
        {
            var sheepEntity = SystemAPI.GetSingleton<ECSEntity>();
            var sheepPrefab = sheepEntity.Prefab;
            var sheepCount = sheepEntity.sheepCount; 

            // Instantiating an entity creates copy entities with the same component types and values.
            var instances = state.EntityManager.Instantiate(sheepPrefab, sheepCount, Allocator.Temp);

            // Unlike new Random(), CreateFromIndex() hashes the random seed
            // so that similar seeds don't produce similar results.
            var random = Random.CreateFromIndex(m_UpdateCounter++);

            foreach (var entity in instances)
            {
                var position = (random.NextFloat3() - new float3(0.5f, 0, 0.5f)) * 20;

                // Get a TransformAspect instance wrapping the entity.
                var transform = SystemAPI.GetAspectRW<TransformAspect>(entity);
                transform.LocalPosition = position;
            }
        }
    }
}

