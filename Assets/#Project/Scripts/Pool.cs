using System;
using System.Collections.Generic;
using UnityEngine;

public class Pool<T>
where T : IPoolClient
{
    public Vector3 startingPos;
    private Transform anchor;
    private GameObject prefab;
    private Queue<T> queue = new();
    [SerializeField] private Camera cam = Camera.main;
    private SpawnPoint spawn;
    private int batch;


    public Pool(Transform anchor, GameObject prefab, SpawnPoint spawn, int batch)
    {
        this.anchor = anchor;
        this.prefab = prefab;
        this.spawn = spawn;
        this.batch = batch;

        startingPos = new(Screen.width, 0, 0);
        startingPos = cam.ScreenToWorldPoint(startingPos);
        spawn.transform.position = startingPos;

        CreateBatch();
    }

    public void Add(T client)
    {
        queue.Enqueue(client);
        client.Sleep();
    }

    public T Get()
    {
        if (queue.Count == 0)
        {
            CreateBatch();
        }

        float rnd = UnityEngine.Random.Range(Screen.height, -Screen.height);
        startingPos.y = rnd;
        startingPos.z = 10;
        startingPos = cam.ScreenToWorldPoint(startingPos);

        T client = queue.Dequeue();
        client.WakeUp(startingPos, anchor.rotation);

        return client;
    }

    private void CreateBatch()
    {
        for (int _ = 0; _ < batch; _++)
        {
            GameObject gameObj = UnityEngine.Object.Instantiate(prefab);

            if (gameObj.TryGetComponent(out T client))
            {
                Add(client);
            }

            else
            {
                throw new ArgumentException("Invalid type for the prefab. It needs to implement an IPoolClient Interface.");
            }
        }
    }


}
