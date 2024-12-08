using UnityEngine;
using UnityEngine.InputSystem;

public class PhotomodeCameraController : MonoBehaviour
{
    [SerializeField] private PhotomodeManager manager;
    [SerializeField] private float lookSpeed = 10f;

    private Vector2 lookInput;

    void Update()
    {
        if (lookInput.sqrMagnitude > 0 && manager.isPhotomodeActive)
        {
            float pitch = lookInput.y * lookSpeed * Time.deltaTime;
            float yaw = lookInput.x * lookSpeed * Time.deltaTime;
            transform.Rotate(-pitch, yaw, 0, Space.Self);
        }
    }

    public void OnLookInput(InputAction.CallbackContext ctx)
    {
        lookInput = ctx.ReadValue<Vector2>();
    }
}
