using UnityEngine;

public class Spawner : MonoBehaviour
{
    private Vector3 minPoint;
    private Vector3 maxPoint;
    private Pool<EnemyBehaviour> pool;


    public void Initialize(EnemyBehaviour enemy, Vector3 minPoint, Vector3 maxPoint, int batch)
    {
        this.minPoint = minPoint;
        this.maxPoint = maxPoint;

        pool = new(enemy.gameObject, batch); // ??
    }

    public void Teleport(EnemyBehaviour enemy)
    {
        pool.Add(enemy);
    }

    public EnemyBehaviour Spawn()
    {
        float rnd = Random.Range(0f, 1f);
        return pool.Get(Vector3.Lerp(minPoint, maxPoint, rnd), Quaternion.identity);
    }

    public void Despawn(EnemyBehaviour enemy)
    {
        pool.Add(enemy);
    }
}
