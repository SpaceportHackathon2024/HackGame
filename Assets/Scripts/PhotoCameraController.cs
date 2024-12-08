using Unity.Cinemachine;
using UnityEngine;
using UnityEngine.InputSystem;

public class PhotomodeCameraController : MonoBehaviour
{
    [SerializeField] private PhotomodeManager manager;
    [SerializeField] private float lookSpeed = 10f;
    [SerializeField] private LayerMask raycastLayerMask;

    private Vector2 lookInput;
    private CinemachineCamera cinCam;
    private Camera cam;

    private void Start()
    {
        cinCam = GetComponent<CinemachineCamera>();
        cam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
    }


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

    public void CastRayFromPhotoCamera()
    {
        // Get the center of the camera's viewport (normalized viewport coordinates: 0-1)
        Vector3 viewportCenter = new Vector3(0.5f, 0.5f, 0f);

        // Convert to a ray
        Ray ray = cam.ViewportPointToRay(viewportCenter);

        // Perform the raycast
        if (Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity, raycastLayerMask))
        {
            Debug.Log($"Hit object: {hit.collider.gameObject.name} at position: {hit.point}");
        }
        else
        {
            Debug.Log("No object hit by the ray.");
        }
    }
}
