using UnityEngine;
using UnityEngine.EventSystems;
public class DraggableZoneItemMv : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private RectTransform zoneRect;
    private Vector2 initialPosition;
    [SerializeField] private GameObject zone_1;
    [SerializeField] private GameObject zone_spawn;

    [SerializeField] private RectTransform allWindow;

    private void Awake()
    {
        if (zone_1 != null)
            zoneRect = zone_1.GetComponent<RectTransform>();

    }
    public void OnBeginDrag(PointerEventData eventData)
    {

        initialPosition = allWindow.anchoredPosition;


    }

    public void OnDrag(PointerEventData eventData)
    {

        allWindow.anchoredPosition += eventData.delta;

    }

    public void OnEndDrag(PointerEventData eventData)
    {

        // Check if the item was dropped inside zone_1's boundaries
        if (zoneRect != null && RectTransformUtility.RectangleContainsScreenPoint(zoneRect, eventData.position, eventData.pressEventCamera))
        {
            allWindow.SetParent(zone_1.transform.parent, true);
            // Move the item to the visual center of zone_1
            allWindow.position = zoneRect.TransformPoint(zoneRect.rect.center);
        }
        else
        {
            // Return the item to its starting position
            //            allWindow.anchoredPosition = initialPosition;
            //            allWindow.transform.SetParent(zone_spawn);
            allWindow.SetParent(zone_spawn.transform, true);

            allWindow.anchoredPosition = initialPosition;
            allWindow.localPosition = Vector3.zero;

        }
        // if the item is located in the same coordinates of zone_1 it puts the item in the center of zone_1, otherwyse it puts it into his initial position
    }

}
