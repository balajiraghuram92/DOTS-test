using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;

public class ECSManager : MonoBehaviour
{
    public GameObject sheepPrefab;
    const int sheepCount = 500; 
}

public struct ECSEntity : IComponentData
{
    public Entity Prefab;
}

public class ECSBaker : Baker<ECSManager>
{
    public override void Bake(ECSManager authoring)
    {
        AddComponent(new ECSEntity { Prefab = GetEntity(authoring.sheepPrefab) });
    }
}