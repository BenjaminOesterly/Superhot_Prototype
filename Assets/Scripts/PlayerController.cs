using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public InputAction moveAction;
    public InputAction jumpAction = new InputAction("Jump", InputActionType.Button, "<Keyboard>/space");
    public InputAction spawnAction = new InputAction("Spawn", InputActionType.Button, "<Keyboard>/e");

    public InputAction lookAction = new InputAction("Look", InputActionType.Value, "<Mouse>/delta");

    public GameObject enemyPrefab;
    public float speed = 5f;
    public float jumpForce = 5f;

    private Rigidbody rb;
    private Vector2 moveInput;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        rb.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ;

        moveAction = new InputAction("Move", InputActionType.Value);
        moveAction.AddCompositeBinding("2DVector")
            .With("Up", "<Keyboard>/w")
            .With("Down", "<Keyboard>/s")
            .With("Left", "<Keyboard>/a")
            .With("Right", "<Keyboard>/d");
    }

    void OnEnable()
    {
        moveAction.Enable();
        jumpAction.Enable();
        spawnAction.Enable();
        lookAction.Enable();
    }

    void OnDisable()
    {
        moveAction.Disable();
        jumpAction.Disable();
        spawnAction.Disable();
        lookAction.Disable();
    }

    void Update()
    {
        moveInput = moveAction.ReadValue<Vector2>();
        Vector2 lookInput = lookAction.ReadValue<Vector2>();

        if (moveInput.magnitude > 0.1f)
        {
            Time.timeScale = 1f;
        }
        else if (lookInput.magnitude > 0.5f)
        {
            Time.timeScale = 0.5f;
        }
        else
        {
            Time.timeScale = 0.05f;
        }

        Time.fixedDeltaTime = 0.02f * Time.timeScale;

        if (spawnAction.WasPressedThisFrame() && enemyPrefab != null)
        {
            Vector3 spawnPos = transform.position + (transform.forward * 3f);
            Instantiate(enemyPrefab, spawnPos, Quaternion.identity);
        }

        if (jumpAction.WasPressedThisFrame())
        {
            if (Physics.Raycast(transform.position, Vector3.down, 1.1f))
            {
                rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            }
        }
    }

    void FixedUpdate()
    {
        Vector3 moveDir = (transform.right * moveInput.x + transform.forward * moveInput.y).normalized;
        rb.linearVelocity = new Vector3(moveDir.x * speed, rb.linearVelocity.y, moveDir.z * speed);
    }
}