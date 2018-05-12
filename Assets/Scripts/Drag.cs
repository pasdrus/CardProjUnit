using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Drag : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler {

    public Transform parentToReturnTo = null;

    public enum Action {ATTACK,UTILITARY,HAND};
    public enum Player { PLAYER,ENEMY};
    public Action typeOfAction = Action.ATTACK;
    public Player typeOfPlayer = Player.PLAYER;

    public void OnBeginDrag(PointerEventData eventData)
    {
        Drag d = eventData.pointerDrag.GetComponent<Drag>();
        string Player = d.typeOfPlayer.ToString();
        if (Player == "PLAYER" && Game.PlayerTurn == true)
        {
            parentToReturnTo = this.transform.parent;

            this.transform.SetParent(this.transform.parent.parent);
            GetComponent<CanvasGroup>().blocksRaycasts = false;
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        Drag d = eventData.pointerDrag.GetComponent<Drag>();
        string Player = d.typeOfPlayer.ToString();
        if (Player == "PLAYER" && Game.PlayerTurn == true)
        {
            //Debug.Log(d.typeOfPlayer);
        //On doit transformer les coordonnées de la souris car on est en mode world space
        //on transforme juste la position z de ce fait
        var screenPoint = Input.mousePosition;
        screenPoint.z = 600.0f;
        this.transform.position = Camera.main.ScreenToWorldPoint(screenPoint);
        //this.transform.position = eventData.position;
        GetComponent<CanvasGroup>().blocksRaycasts = false;
        }

        
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Drag d = eventData.pointerDrag.GetComponent<Drag>();
        string Player = d.typeOfPlayer.ToString();
        if (Player == "PLAYER")
        {
            this.transform.SetParent(parentToReturnTo);

        //On remet la coordonnée Z à 0 car on est en mode world space
        var posZ = this.transform.position;
        this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, 0);

        GetComponent<CanvasGroup>().blocksRaycasts = true;
        }


            
    }

}