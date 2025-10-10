using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControl : MonoBehaviour
{
    [SerializeField] private InputActionAsset actions;
    [SerializeField] private float speed = 1f;
    private InputAction movementInput;
    private Vector3 movement;
    private Vector3 startingPosition;
    private Vector3 top;
    private Vector3 bottom;


    public void Initialize(InputActionAsset actions, Vector3 startingPosition, Vector3 bottom, Vector3 top)
    {
        this.actions = actions;
        this.startingPosition = startingPosition;
        SetPosition(startingPosition);
        this.top = top;
        this.bottom = bottom;
    }

    public void Process()
    {
        Vector2 input = movementInput.ReadValue<Vector2>();
        movement = new(input.x, input.y, 0f);

        Move();
    }


    private void OnEnable()
    {
        actions.FindActionMap("Player").Enable();

    }

    private void OnDisable()
    {
        actions.FindActionMap("Player").Disable();
    }

    private void Awake()
    {
        movementInput = actions.FindActionMap("Player").FindAction("Movement");
    }

    private void SetPosition(Vector3 position)
    {
        transform.position = position;
    }

    private void Move()
    {
        transform.position += movement * speed * Time.deltaTime;
    }
}
