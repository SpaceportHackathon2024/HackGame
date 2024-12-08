using UnityEngine;
using UnityEngine.EventSystems;

public class AtomicElementDrag : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private Canvas canvas;
    private RectTransform rectTransform;
    private CanvasGroup canvasGroup;
    private Vector2 originalPosition;

    public AtomicElement element; // Reference to the element this is attached to

    void Awake()
    {
        canvas = GetComponentInParent<Canvas>();
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        originalPosition = rectTransform.anchoredPosition;
        canvasGroup.alpha = 0.6f; // Make it slightly transparent while dragging
        canvasGroup.blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        rectTransform.anchoredPosition = eventData.position / canvas.scaleFactor; // Adjust position based on mouse
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        canvasGroup.alpha = 1f;
        canvasGroup.blocksRaycasts = true;
        // Check if dropped in a valid target position, then combine or destroy the element
        // If dropped into an invalid area, reset its position
        if (eventData.pointerCurrentRaycast.gameObject == null)
        {
            rectTransform.anchoredPosition = originalPosition; // Reset position
        }
    }
}
