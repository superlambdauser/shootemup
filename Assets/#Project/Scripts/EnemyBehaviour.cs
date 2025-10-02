using UnityEngine;

public class EnemyBehaviour : MonoBehaviour, IPoolClient
{
    [HideInInspector] public SpawnPoint spawn;
    [SerializeField] private float speed = 5f;


    private void Update()
    {
        transform.position += -Vector3.right * speed * Time.deltaTime;
    }

    public void WakeUp(Vector3 position, Quaternion rotation)
    {
        gameObject.SetActive(true);
        transform.SetPositionAndRotation(position, rotation);
    }
    public void Sleep()
    {
        gameObject.SetActive(false);
    }
    private void OnBecameInvisible()
    {
        spawn.Teleport(this);
    }
}
