using UnityEngine;
using System.Collections;
using Unity.Entities;
using Unity.Transforms;

public readonly partial struct ECSSystemAspect: IAspect
{
    public readonly Entity Entity;

    private readonly TransformAspect _transformAspect;

    private readonly RefRO<ECSEntity> _ecsManager;

    public int SheepCount => _ecsManager.ValueRO.sheepCount;
    public Entity SheepPrefab => _ecsManager.ValueRO.Prefab; 


    public UniformScaleTransform GetRandomSheepTransform()
    {
        return new UniformScaleTransform
        {
            Position =,

        }
    }

}

