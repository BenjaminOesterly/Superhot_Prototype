using UnityEngine;
using UnityEngine.InputSystem;

public class MouseLook : MonoBehaviour
{
    public InputAction lookAction = new InputAction("Look", InputActionType.Value, "<Mouse>/delta");

    public Transform playerBody;
    public float mouseSensitivity = 15f;

    private float xRotation = 0f;

    void OnEnable() { lookAction.Enable(); }
    void OnDisable() { lookAction.Disable(); }

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;

        xRotation = 0f;
        transform.localRotation = Quaternion.Euler(0f, 0f, 0f);
    }

    void Update()
    {
        if (Time.timeScale == 0 || Time.time < 0.1f) return;

        Vector2 lookInput = lookAction.ReadValue<Vector2>() * mouseSensitivity * Time.unscaledDeltaTime;

        xRotation -= lookInput.y;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        playerBody.Rotate(Vector3.up * lookInput.x);
    }
}