using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerShooting : MonoBehaviour
{
    private Pool<BulletBehaviour> pool;
    private InputActionAsset actions;
    private InputAction userInput;



    #region Unity events
    void Awake()
    {
        userInput = actions.FindActionMap("Player").FindAction("Shoot");
    }

    private void OnEnable()
    {
        actions.FindActionMap("Player").Enable();
    }

    private void OnDisable()
    {
        actions.FindActionMap("Player").Disable();
    }
    #endregion

    #region Custom Methods
    public void Initialize(BulletBehaviour bullet, int batch)
    {
        pool = new(bullet.gameObject, batch);
    }

    public void Teleport(BulletBehaviour bullet)
    {
        pool.Add(bullet);
    }

    public BulletBehaviour Spawn(Vector3 position, Quaternion rotation)
    {
        return pool.Get(position, rotation);
    }

    public void Despawn(BulletBehaviour bullet)
    {
        pool.Add(bullet);
    }

    public Vector3 GetDirection()
    {
        Vector3 direction = Input.mousePosition;
        direction = Camera.main.ScreenToWorldPoint(direction);

        return direction;
    }

    public void Shoot()
    {
        bool isClicking = userInput.ReadValue<bool>();
        Vector3 direction = GetDirection();
        if (isClicking) Spawn(transform.position, Quaternion.Euler(direction.normalized));
    }
    #endregion
}
