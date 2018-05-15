using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

[System.Serializable]
public class OnClickAddActionDeck : MonoBehaviour, IPointerDownHandler
{

    public ActionDeck myDeck;
    public ActionCardData myCard;

    // au click on ajout la carte à la liste
    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log(myCard.Name + " Was Clicked.");
        //On ne peut pas ajouter + de 15 cartes dans le deck.
        if (myDeck.ActionCardsList.Count < 15 && Verif(myCard) == true)
        {
            myDeck.ActionCardsList.Add(myCard);
            Debug.Log(myDeck.ActionCardsList.Count);
        }
    }

    public bool Verif(ActionCardData c)
    {
        int nb = 0;
        bool test = true;
        foreach (ActionCardData card in myDeck.ActionCardsList)
        {
            if (card.Id == myCard.Id)
            {
                nb++;
            }
        }
        if (nb == 3)
        {
            test = false;
        }
        return test;
    }
}
