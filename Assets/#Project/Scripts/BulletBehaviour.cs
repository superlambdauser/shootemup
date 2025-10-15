using UnityEngine;

public class BulletBehaviour : MonoBehaviour, IPoolClient
{
    public bool Alive => gameObject.activeInHierarchy;


    [SerializeField] private Vector3 speed;
    private GameManager gameManager;


    #region Unity Events
    void OnTriggerEnter(Collider other)
    {
        gameManager.BulletFallAsleep(this);
    }
    private void OnBecameInvisible()
    {
        gameManager.BulletFallAsleep(this);
    }
    #endregion

    #region Custom Methods 
    public void Initialize(GameManager gameManager, PlayerShooting weapon, float speed)
    {
        this.gameManager = gameManager;

        this.speed = speed * weapon.transform.rotation.eulerAngles; // hummmmmmmmmmm à vérifier
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
    #endregion
}
