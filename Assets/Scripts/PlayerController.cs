using TMPro;
using UnityEngine;

namespace MeetAndTalk.Demo
{
    public class PlayerController: MonoBehaviour
    {
        [Header("Localization")]
        public TMPro.TMP_Text Lanuage;

        [Header("Interaction")]
        public BoxCollider BoxCollider;
        public GameObject InteractionUI;
        public TMP_Text InteractionText;

        [Header("Camera")]
        public Camera playerCamera;

        public bool Interactable;

        private GameObject interactionGameObject;

        void Start()
        {
            InteractionUI.SetActive(false);
        }

        public void SetupInteractable(bool mode)
        {
            Interactable = mode;
        }

        void Update()
        {
            if (Interactable)
            {
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
            }
            else
            {
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
            }

            if (interactionGameObject != null && Input.GetKeyDown(KeyCode.E))
            {
                interactionGameObject.transform.SendMessage("Interaction", SendMessageOptions.DontRequireReceiver);
            }

            Lanuage.text = $"Language:\n<size=64>{Localization.LocalizationManager.Instance.SelectedLang()}";
            if (Input.GetKeyDown(KeyCode.U))
            {
                Localization.LocalizationManager.Instance.selectedLang = SystemLanguage.English;
            }
            if (Input.GetKeyDown(KeyCode.P))
            {
                Localization.LocalizationManager.Instance.selectedLang = SystemLanguage.Polish;
            }
        }

        public void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.GetComponent<DemoInteraction>() != null && Interactable)
            {
                interactionGameObject = other.gameObject;

                InteractionUI.SetActive(true);
                InteractionText.text = other.gameObject.GetComponent<DemoInteraction>().InteractionText;
            }
        }

        public void OnTriggerExit(Collider other)
        {
            if (other.gameObject.GetComponent<DemoInteraction>() != null && Interactable)
            {
                InteractionUI.SetActive(false);
                interactionGameObject = null;
            }
        }
    }
}
