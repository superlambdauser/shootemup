using UnityEngine;

public class EnemyBehaviour : MonoBehaviour, IPoolClient
{
    public bool Alive => gameObject.activeInHierarchy; // Alias


    [SerializeField] private Vector3 speed = Vector3.left * 10f;
    private GameManager gameManager;


    public void Initialize(GameManager gameManager)
    {
        this.gameManager = gameManager;
    }

    public void WakeUp(Vector3 position, Quaternion rotation)
    {
        gameObject.SetActive(true);
        transform.SetPositionAndRotation(position, rotation);
    }
    
    public void Process()
    {
        if (!Alive) return;

        transform.Translate(speed * Time.deltaTime);
    }
    
    public void Sleep()
    {
        gameObject.SetActive(false);
    }
    private void OnBecameInvisible()
    {
        gameManager.EnemyFallAsleep(this);
    }
}
