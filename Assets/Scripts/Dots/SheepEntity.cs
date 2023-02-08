using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;

[AddComponentMenu("ECS-Test/ Add Sheep Data")]
public class SheepEntityAuthoring : MonoBehaviour
{
    public int id = 1;
    public int movementSpeed = 1;

    public class Baker : Baker<SheepEntityAuthoring>
    {
        public override void Bake(SheepEntityAuthoring authoring)
        {
            var sheepData = new sheepID
            {
                id = authoring.id
            };

            AddComponent(sheepData);
        }
    }
}

struct sheepID : IComponentData
{
    public int id;
}
