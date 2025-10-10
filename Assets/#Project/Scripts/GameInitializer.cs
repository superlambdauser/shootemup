
using UnityEngine;
using UnityEngine.InputSystem;

public class GameInitializer : MonoBehaviour
{
    [SerializeField] private CameraManager cameraManager;
    [SerializeField] private GameManager gameManager;
    [SerializeField] private PlayerControl player;
    [SerializeField] private InputActionAsset actions;
    [SerializeField] private Vector3 playerPosition;
    [SerializeField] private EnemyBehaviour enemyPrefab;
    [SerializeField] private Spawner spawner;
    [SerializeField] private Vector3 cameraPosition;
    [SerializeField] private Quaternion cameraRotation;
    [SerializeField] private int batch;
    [SerializeField] private float cooldown;
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
        player.Initialize(actions, playerPosition, min, max);
        spawner.Initialize(enemyPrefab, min, max, batch);
        gameManager.Initialize(spawner, player, cooldown);
    }
}
