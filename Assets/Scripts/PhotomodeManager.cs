using UnityEngine;
using UnityEngine.Events;
using Unity.Cinemachine;
using UnityEngine.InputSystem;

public class PhotomodeManager : MonoBehaviour
{
    [SerializeField] private GameObject photomodeUI;
    [SerializeField] private GameObject playerController;
    [SerializeField] private CinemachineCamera photomodeCamera;
    [SerializeField] private UnityEvent onPhotomodeEnter;
    [SerializeField] private UnityEvent onPhotomodeExit;

    [SerializeField] private string screenshotFolder = "Screenshots";

    [HideInInspector]
    public bool isPhotomodeActive = false;

    public void TogglePhotomode(InputAction.CallbackContext ctx)
    {
        if (ctx.performed)
        {
            isPhotomodeActive = !isPhotomodeActive;

            //photomodeUI.SetActive(isPhotomodeActive);
            //playerController.SetActive(!isPhotomodeActive);
            photomodeCamera.Priority = isPhotomodeActive ? 10 : -1;
            Cursor.visible = isPhotomodeActive;
            Cursor.lockState = isPhotomodeActive ? CursorLockMode.None : CursorLockMode.Locked;

            //if (isPhotomodeActive)
            //    onPhotomodeEnter.Invoke();
            //else
            //    onPhotomodeExit.Invoke();

        }
    }

    public void TakeScreenshot(InputAction.CallbackContext ctx)
    {
        if (ctx.performed && isPhotomodeActive)
        {
            string folderPath = $"{Application.dataPath}/{screenshotFolder}";

            if (!System.IO.Directory.Exists(folderPath))
                System.IO.Directory.CreateDirectory(folderPath);

            string screenshotPath = $"{folderPath}/Screenshot_{System.DateTime.Now:yyyyMMdd_HHmmss}.png";
            ScreenCapture.CaptureScreenshot(screenshotPath);
            Debug.Log($"Screenshot saved to: {screenshotPath}");
        }
    }
}
