using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;

public class ECSInterface : MonoBehaviour
{
    World world;
    void Start()
    {
        world = World.DefaultGameObjectInjectionWorld;
        Debug.Log("All Entities" + world.EntityManager.GetAllEntities().Length);

        EntityQuery entityQuery = world.EntityManager.CreateEntityQuery(ComponentType.ReadOnly<sheepID>());
        Debug.Log("Sheep Count" + entityQuery.CalculateEntityCount());
    }
}
