using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

[System.Serializable]
public class click : MonoBehaviour, IPointerDownHandler
{

    public deck deckl;
    public Card1 c;

    // au click on ajout la carte à la liste
    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log(c.name + " Was Clicked.");
        deckl.deckliste.Add(c);
    }
}
