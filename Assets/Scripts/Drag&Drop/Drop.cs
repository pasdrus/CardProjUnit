using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Drop : MonoBehaviour, IDropHandler, IPointerEnterHandler, IPointerExitHandler {

    public Drag.Action typeOfAction = Drag.Action.HAND;
    public Drag.Player typeOfPlayer = Drag.Player.PLAYER;
    private bool PlayerTurn1;

    public void Update()
    {
        GameObject PlayerTurn = GameObject.Find("Game");
        Game Turnplayer = PlayerTurn.GetComponent<Game>();
        PlayerTurn1 = Turnplayer.PlayerTurn;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
    }

    public void OnPointerExit(PointerEventData eventData)
    {
    }

    public void OnDrop(PointerEventData eventData) {
        //Debug.Log(eventData.pointerDrag.name + " a été posé sur" + gameObject.name);
        
        Drag d = eventData.pointerDrag.GetComponent<Drag>();
        
        //string Player = d.typeOfPlayer.ToString();
        if (PlayerTurn1 == true && gameObject.transform.childCount<3)
        {
            if (d != null)
            {
                if (typeOfAction == d.typeOfAction && typeOfPlayer == d.typeOfPlayer || typeOfAction == Drag.Action.HAND && typeOfPlayer == d.typeOfPlayer)
                {
                    d.parentToReturnTo = this.transform;
                    
                }
            }
        }
        else
        {
            GameObject PlayerHand= GameObject.Find("PlayerHand");
            d.parentToReturnTo = PlayerHand.transform;
        }
    }
}
