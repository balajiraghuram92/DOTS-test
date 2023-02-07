using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Jobs;
using Unity.Jobs;

public class SheepManager : MonoBehaviour
{ 
    public GameObject sheepPrefab;
    const int numsheep = 500; 
    public Transform[] sheepList;

    public void Start()
    {
        sheepList = new Transform[numsheep];
        for (int i = 0; i < numsheep; i++)
        {
            Vector3 pos = new Vector3(Random.Range(-50, 50), 0, Random.Range(-50, 50));
            GameObject sheep = Instantiate(sheepPrefab, pos, Quaternion.identity);
            sheepList[i] = sheep.transform;
        } 
    }

    void Update()
    { 
            foreach (var sheep in sheepList)
            {
                MoveObjects(sheep.transform);
            } 
    }  

    void MoveObjects(Transform transform)
    {
    transform.Translate(0, 0, 0.1f);

    if (transform.position.z > 28)
        transform.position = new Vector3(Random.Range(-48, 48), transform.position.y, -28);
    }
}
