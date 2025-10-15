using UnityEngine;
using UnityEngine.InputSystem;

public class GameInitializer : MonoBehaviour
{
    [Header("Game Data :")]

    [Header("Managers :")]
    [SerializeField] private GameManager gameManager;
    [SerializeField] private CameraManager cameraManager;

    [Header("Player :")]
    [SerializeField] private PlayerControl player;
    [SerializeField] private InputActionAsset actions;
    [SerializeField] private Vector3 playerPosition;

    [Header("Camera :")]
    [SerializeField] private Vector3 cameraPosition;
    [SerializeField] private Quaternion cameraRotation;

    [Header("Enemes :")]
    [SerializeField] private EnemyBehaviour enemyPrefab;

    [Header("Spawner :")]
    [SerializeField] private Spawner spawner;
    [SerializeField] private int enemiesBatch;
    [SerializeField] private float enemiesSpawnCooldown;

    [Header("Weapon/Bullets shooting :")]
    [SerializeField] private PlayerShooting weapon;
    [SerializeField] private float bulletsRateCooldown;

    [Header("Screen/World positions data :")]
    [SerializeField] private float distanceFromCamera = 10;


    private void Start()
    {
        CreateObjects();
        InitializeObjects();
        Destroy(gameObject);
    }

    private void CreateObjects()
    {
        cameraManager = Instantiate(cameraManager);
        spawner = Instantiate(spawner);
        player = Instantiate(player);
        gameManager = Instantiate(gameManager);
    }
    private void InitializeObjects()
    {
        cameraManager.Initialize(cameraPosition, cameraRotation);
        (Vector3 min, Vector3 max) = cameraManager.GetRightBorderPoints(distanceFromCamera);
        playerPosition = new (0f, 0f, distanceFromCamera);
        player.Initialize(actions, playerPosition, cameraManager.cam);
        spawner.Initialize(enemyPrefab, min, max, enemiesBatch);
        gameManager.Initialize(spawner, player, weapon, enemiesSpawnCooldown, bulletsRateCooldown);
    }
}
