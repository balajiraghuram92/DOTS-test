using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Jobs;
using Unity.Jobs;

public class SheepManageJobs : MonoBehaviour
{ 
    public GameObject sheepPrefab;
    const int numsheep = 500;

    struct moveJob : IJobParallelForTransform
    {
        public void Execute(int index, TransformAccess transform)
        {
            transform.position += 0.1f * (transform.rotation * new Vector3(0, 0, 1));

            if (transform.position.z > 28)
                transform.position = new Vector3(transform.position.x, 0, -28);
        }
    }

    moveJob job;
    JobHandle moveHandle;
    TransformAccessArray transforms;
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

        transforms = new TransformAccessArray(sheepList);
    }

    void Update()
    { 
            job = new moveJob { };
            moveHandle = job.Schedule(transforms); 
    }

    private void LateUpdate()
    { 
            moveHandle.Complete();
    }

    private void OnDestroy()
    { 
        if(transforms.length > 0)
            transforms.Dispose();
    }  
}
