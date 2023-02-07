using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;

[AddComponentMenu("ECS-Test/Add ECSManager")]
public class ECSManager : MonoBehaviour
{
    public GameObject sheepPrefab;
    public int sheepCount = 500; 
}

public struct ECSEntity : IComponentData
{
    public Entity Prefab;
    public int sheepCount;
}

public class ECSBaker : Baker<ECSManager>
{
    public override void Bake(ECSManager authoring)
    {
        AddComponent(new ECSEntity
        {
            Prefab = GetEntity(authoring.sheepPrefab),
            sheepCount = authoring.sheepCount
        }); ;
    }
}