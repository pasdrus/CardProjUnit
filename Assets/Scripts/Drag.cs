using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Networking;

public class Drag : NetworkBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler {

    public Transform parentToReturnTo = null;

    public enum Action {ATTACK,UTILITARY,HAND};
    public enum Player { Player1,Player2};
    public Action typeOfAction = Action.ATTACK;
    public Player player = Player.Player1;

    public void OnBeginDrag(PointerEventData eventData)
    {
        parentToReturnTo = this.transform.parent;

        this.transform.SetParent(this.transform.parent.parent);
        GetComponent<CanvasGroup>().blocksRaycasts = false;

    }

    public void OnDrag(PointerEventData eventData)
    {
        //On doit transformer les coordonnées de la souris car on est en mode world space
        //on transforme juste la position z de ce fait
        var screenPoint = Input.mousePosition;
        screenPoint.z = 200.0f;
        this.transform.position = Camera.main.ScreenToWorldPoint(screenPoint);
        //this.transform.position = eventData.position;
        GetComponent<CanvasGroup>().blocksRaycasts = false;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        this.transform.SetParent(parentToReturnTo);
        GetComponent<CanvasGroup>().blocksRaycasts = true;
    }

}
