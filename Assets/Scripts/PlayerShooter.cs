using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerShooter : MonoBehaviour
{
    public InputAction shootAction = new InputAction("Shoot", InputActionType.Button, "<Mouse>/leftButton");
    public GameObject bulletPrefab;

    void OnEnable() { shootAction.Enable(); }
    void OnDisable() { shootAction.Disable(); }

    void Update()
    {
        if (shootAction.WasPressedThisFrame())
        {
            Instantiate(bulletPrefab, transform.position + transform.forward, transform.rotation);
        }
    }
}