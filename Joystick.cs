using UnityEngine;
using UnityEngine.EventSystems;


public class Joystick : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    Transform pointer;
    Vector2 centerPos,beginPos,dragPos,dir;
    float r;

    void Start(){
        pointer = transform.GetChild(0);
        r = GetComponent<RectTransform>().sizeDelta.x / 2;
        centerPos = pointer.position;
    }


    public void OnBeginDrag(PointerEventData eventData)
    {

        beginPos = eventData.position;
    }

    public void OnDrag(PointerEventData eventData)
    {
        dragPos = eventData.position;
        dir = dragPos - beginPos;
        pointer.position = Vector2.Distance(dragPos, beginPos) > r ? (centerPos + dir.normalized * r) : (centerPos + dir);
        
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        dragPos = Vector2.zero;
        beginPos = Vector2.zero;
        pointer.position = centerPos;
    }

}
