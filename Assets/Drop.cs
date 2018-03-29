using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Drop : MonoBehaviour, IDropHandler, IPointerEnterHandler, IPointerExitHandler {

    public Drag.Action typeOfAction = Drag.Action.HAND;

    public void OnPointerEnter(PointerEventData eventData)
    {
    }

    public void OnPointerExit(PointerEventData eventData)
    {
    }

    public void OnDrop(PointerEventData eventData) {
        Debug.Log(eventData.pointerDrag.name + " a été posé sur" + gameObject.name);

        Drag d = eventData.pointerDrag.GetComponent<Drag>();
        if(d != null)
        {
            if(typeOfAction == d.typeOfAction || typeOfAction == Drag.Action.HAND) {
                d.parentToReturnTo= this.transform;
            }
            
        }
    }
}
