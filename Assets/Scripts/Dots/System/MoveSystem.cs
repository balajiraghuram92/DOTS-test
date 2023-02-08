using Unity.Entities;
using Unity.Burst;
using Unity.Transforms;
using Unity.Mathematics;

[BurstCompile]
public partial struct MoveSystem : ISystem
{
    public void OnCreate(ref SystemState state)
    {
        state.RequireForUpdate<sheepID>();
    }

    public void OnDestroy(ref SystemState state)
    { 
    }

    public void OnUpdate(ref SystemState state)
    {
        var random = Random.CreateFromIndex(1);
        foreach (var (transform, movementSpeed) in SystemAPI.Query<RefRW<LocalTransform> , RefRO<sheepID>>())
        {
            transform.ValueRW = transform.ValueRW.Translate(new float3(0, 0, 0.1f)* SystemAPI.Time.DeltaTime);

            if (transform.ValueRO.Position.z > 28)
                transform.ValueRW.Position = new float3(random.NextFloat(-48, 48), transform.ValueRO.Position.y, -28);
        }
    }
}
