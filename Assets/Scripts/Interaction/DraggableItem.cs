using UnityEngine;
using UnityEngine.EventSystems;
public class DraggableItem : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    [SerializeField] private RectTransform allWindow;

    public void OnBeginDrag(PointerEventData eventData)
    {
//        throw new System.NotImplementedException();
    }

    public void OnDrag(PointerEventData eventData)
    {
//        dragRectTransform.transform.position = eventData.position;
        allWindow.anchoredPosition += eventData.delta;
//        throw new System.NotImplementedException();
    }

    public void OnEndDrag(PointerEventData eventData)
    {
//        throw new System.NotImplementedException();
    }
    
}
