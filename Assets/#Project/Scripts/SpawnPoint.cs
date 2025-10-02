using System.Collections;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    [SerializeField] private float cooldown = 1f;
    [SerializeField] private GameObject prefab;
    private Pool<EnemyBehaviour> pool;


    private void Start()
    {
        pool = new(transform, prefab, this, 10);

        StartCoroutine(Spawn());
    }

    private IEnumerator Spawn()
    {
        while (true)
        {
            yield return new WaitForSeconds(cooldown);
            EnemyBehaviour enemy = pool.Get();
            enemy.spawn = this;
        }
    }
    public void Teleport(EnemyBehaviour enemy)
    {
        pool.Add(enemy);
    }
    

}
