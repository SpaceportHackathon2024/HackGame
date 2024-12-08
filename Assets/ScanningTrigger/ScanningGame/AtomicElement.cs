using TMPro;
using UnityEngine;

public class AtomicElement : MonoBehaviour
{
    public string elementName;       // Name of the element (e.g., "H", "He")
    public int atomicNumber;         // Atomic number (e.g., 1 for H)
    public float atomicMass;         // Atomic mass (e.g., 1.008 for H)

    //public Sprite elementSprite;     // Sprite for the element's image
    public GameObject elementInfoPanel; // Panel to show element info when hovered

    private bool isDragging = false; // Track if the element is being dragged

    void Update()
    {
        if (isDragging)
        {
            // Update position of the element while it's being dragged
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePosition.z = 0;
            transform.position = mousePosition;
        }
    }

    public void OnPointerDown()
    {
        isDragging = true;
    }

    public void OnPointerUp()
    {
        isDragging = false;
    }

    public void ShowElementInfo()
    {
        // Display element information in the left panel when the cursor is over it
        elementInfoPanel.SetActive(true);
        elementInfoPanel.GetComponentInChildren<TextMeshProUGUI>().text = $"Name: {elementName}\nAtomic Number: {atomicNumber}\nAtomic Mass: {atomicMass}";
    }

    public void HideElementInfo()
    {
        elementInfoPanel.SetActive(false);
    }
}
