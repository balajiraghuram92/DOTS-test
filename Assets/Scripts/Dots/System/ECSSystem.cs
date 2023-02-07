using UnityEngine;
using System.Collections;
using Unity.Entities;
using Unity.Burst;

[BurstCompile]
[UpdateInGroup(typeof(InitializationSystemGroup))]
public partial struct ECSSystem : ISystem
{
    [BurstCompile]
    public void OnCreate(ref SystemState state)
    {
        state.RequireForUpdate<ECSEntity>();
    }

    [BurstCompile]
    public void OnDestroy(ref SystemState state)
    {
         
    }

    [BurstCompile]
    public void OnUpdate(ref SystemState state)
    {
        state.Enabled = false;

        var ecsEntity = SystemAPI.GetSingletonEntity<ECSEntity>();
        var sheepPrefab = SystemAPI.GetAspectRO <ECSSystemAspect>(ecsEntity);

        var ecb = new EntityCommandBuffer(Unity.Collections.Allocator.Temp);
        for( var i = 0; i < sheepPrefab.SheepCount; i++)
        {
            ecb.Instantiate(sheepPrefab.SheepPrefab);
        }

        ecb.Playback(state.EntityManager);
    }
}

