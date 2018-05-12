using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Drop : MonoBehaviour, IDropHandler, IPointerEnterHandler, IPointerExitHandler {

    public Drag.Action typeOfAction = Drag.Action.HAND;
    public Drag.Player typeOfPlayer = Drag.Player.PLAYER;

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
            if(typeOfAction == d.typeOfAction && typeOfPlayer == d.typeOfPlayer || typeOfAction == Drag.Action.HAND && typeOfPlayer == d.typeOfPlayer) {
                d.parentToReturnTo= this.transform;
                
                /*
                CardDisplay1 carte = eventData.pointerDrag.GetComponent<CardDisplay1>();
                Debug.Log(carte.multAttackText.text);
                int attaque = int.Parse(carte.multAttackText.text);
                int stamina = int.Parse(carte.staminaText.text);
                Enemy.ReceiveDamage(attaque);
                Player.SpendStamina(stamina);
                */
            }
            
        }
    }
}
