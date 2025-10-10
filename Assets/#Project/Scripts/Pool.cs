using System.Collections.Generic;
using UnityEngine;


// A Pool can be seen as a discard in which you can draw
public class Pool<T>
where T : IPoolClient
{
    private GameObject prefab; 
    private Queue<T> queue = new(); 
    private int batch;


    public Pool(GameObject prefab, int batch)
    {
        if (prefab.GetComponent<IPoolClient>() == null)
        {
            throw new System.ArgumentException("Prefab must implement IPoolClient Interface.");
        }

        this.prefab = prefab;
        this.batch = batch;

        CreateBatch();
    }

    public void Add(T client)
    {
        queue.Enqueue(client);
        client.Sleep();
    }

    public T Get(Vector3 position, Quaternion rotation)
    {
        if (queue.Count == 0) CreateBatch();

        T client = queue.Dequeue();

        client.WakeUp(position, rotation);

        return client;
    }

    private void CreateBatch()
    {
        for (int _ = 0; _ < batch; _++)
        {
            GameObject gameObj = Object.Instantiate(prefab);

            T client = gameObj.GetComponent<T>();

            Add(client);
        }
    }


}
