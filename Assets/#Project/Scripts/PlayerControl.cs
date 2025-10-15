using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControl : MonoBehaviour
{
    [SerializeField] private InputActionAsset actions;
    [SerializeField] private float speed = 1f;
    [SerializeField] private int lives = 3;
    private InputAction movementInput;
    private Vector3 movement;
    private Camera mainCam;


    private void Awake()
    {
        movementInput = actions.FindActionMap("Player").FindAction("Movement");
    }

    private void OnEnable()
    {
        actions.FindActionMap("Player").Enable();

    }

    private void OnDisable()
    {
        actions.FindActionMap("Player").Disable();
    }

    private void OnTriggerEnter(Collider other)
    {
        // Debug.Log($"COllision with {other}");

        if (other.CompareTag("Enemy"))
        {
            lives -= 1;
            // Debug.Log($"lives = {lives}");
        }
    }

    public void Initialize(InputActionAsset actions, Vector3 startingPosition, Camera mainCam)
    {
        this.actions = actions;
        this.mainCam = mainCam;
        SetPosition(startingPosition);
    }

    public void Process()
    {
        Vector2 input = movementInput.ReadValue<Vector2>();
        movement = new(input.x, input.y, 0f);
        Move();

        if (!(input.x == 0) || !(input.y == 0)) ClampToScreen();
        // Debug.Log("Screen size: " + Screen.width + " x " + Screen.height);
    }



    private void SetPosition(Vector3 position)
    {
        transform.position = position;
    }

    private void Move()
    {
        transform.position += speed * Time.deltaTime * movement;
        // Debug.Log("After movement: " + transform.position);
    }

    private void ClampToScreen()
    {
        // Get screen position
        Vector3 screenPosition = mainCam.WorldToScreenPoint(transform.position);
        // Debug.Log("Screen position: " + screenPosition);

        // Compare screen position and clamp it
        screenPosition.x = Mathf.Clamp(screenPosition.x, 0f, Screen.width);
        screenPosition.y = Mathf.Clamp(screenPosition.y, 0f, Screen.height);
        // Debug.Log("Clamped screen pos: " + screenPosition);

        // Convert back to world coordinates
        Vector3 clampedWordPosition = mainCam.ScreenToWorldPoint(screenPosition);
        // Debug.Log("Back to world: " + clampedWordPosition);

        // Apply changes
        transform.position = clampedWordPosition;
    }

}
